    using UnityEngine.SceneManagement;
    
    public void RestartScene(){      
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
    
        }//RestartScene
