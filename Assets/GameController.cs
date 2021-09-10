using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static int numboids = 100;

    static GameController Instance;
    [SerializeField]
    Button buttonGameObject;
    [SerializeField]
    Button buttonECS;
    [SerializeField]
    Button buttonECSJ;
    [SerializeField]
    Button buttonECSSJ;
    [SerializeField]
    InputField inputfieldBOID;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        Instance = this;

        buttonGameObject.onClick.AddListener(OnClickGameObject);
        buttonECS.onClick.AddListener(OnClickECS);
        buttonECSJ.onClick.AddListener(OnClickECSJ);
        buttonECSSJ.onClick.AddListener(OnClickECSSJ);
        inputfieldBOID.onValueChanged.AddListener(OnInputFieldBoid);

        inputfieldBOID.text = numboids.ToString();
    }

    void OnClickGameObject()
    {
        SceneManager.LoadScene("GameObjects");
    }

    void OnClickECS()
    {
        SceneManager.LoadScene("ECS");
    }

    void OnClickECSJ()
    {
        SceneManager.LoadScene("ECS + Jobs");
    }

    void OnClickECSSJ()
    {
        SceneManager.LoadScene("ECS + Superfast Jobs");
    }

    void OnInputFieldBoid( string newInput)
    {
        int result;
        if ( int.TryParse(newInput, out result) )
        {
            numboids = result;
        }
        else
        {
            inputfieldBOID.text = numboids.ToString();
        }
    }
}
