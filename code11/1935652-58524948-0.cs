    public class GameManager : MonoBehaviour
    {
    
        bool GameHasEnded = false;
    
        public float restartDelay = 1f;
        public void GameOver()
        {
            if (GameHasEnded == false)
            {
                GameHasEnded = true;
                Debug.Log("GAME OVER");
                Invoke("Restart", restartDelay);
            }
        }
        void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
