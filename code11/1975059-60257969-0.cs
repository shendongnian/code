    public class SceneSwitch : MonoBehaviour 
    {  
        private void OnTriggerEnter2D(Collider2D other)
        {
            SceneManager.LoadScene(0);
        }
    }
