    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    public class Save : MonoBehaviour
    {
      InputField userNameField;
	   void Start()
	   {
		userNameField = GetComponent<InputField>();
	   }
       public void SaveText()
	   {		
          PlayerPrefs.SetString("userName", userNameField.text);
	      Debug.Log(userNameField.text);
	   }
	    public void MoveScene(string sceneToLoad)
	   {
		SceneManager.LoadScene(sceneToLoad);
	   }
    }
