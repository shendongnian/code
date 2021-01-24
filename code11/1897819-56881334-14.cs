    public class LoadNextScene : MonoBehaviour
    {
        [SerializeField] private int nexSceneIndex;
    
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
    
            MySceneManager.LoadScene(nexSceneIndex, this);
        }
    }
    
