    public class RestartButtonL1 : MonoBehaviour
    {
        // reference the CounterScript here by drag and drop
        // the acording GameObject from the scene into this field
        public CounterScript counter;
    
        public void restartScene()
        {
            counter.scorevalue = 0;
            SceneManager.LoadScene("GameSceneA");
        }
    }
