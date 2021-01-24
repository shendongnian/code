     using UnityEngine;
     using UnityEngine.SceneManagement;
    
     public class GameManager : MonoBehaviour{
         public void Endgame();
         bool gameHasEnded = false;
    
         public void CompleteLevel ()
         {
             Debug.Log("Level Won");
         }
    
    
    
          public void Endgame()
          {
             if (gameHasEnded = false)
             {
                 gameHasEnded = true;
                 Invoke("Restart, restartDelay");
                 Debug.Log("GAME OVER");
             }
    
          }
    }
