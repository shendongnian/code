     using System.Linq;
     ...
     if (Pictures.All(picture => picture.rotation.z == 0)) {
       // Win 
       YouWin = true;
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(currentSceneIndex + 1);
     }
