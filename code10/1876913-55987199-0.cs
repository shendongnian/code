    public UnityEngine.UI.InputField sceneInputField; //Refence to your inputField
    
    public void ChangeSceneBasedOnInputField() //Code that needs to be called
     {
          UnityEngine.SceneManagement.SceneManager.LoadScene(sceneInputField.text);  
         //This way you can type either the index of the scene or it's name
         //Will throw an error if it can`t find the scene
    } 
