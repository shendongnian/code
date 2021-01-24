    using UnityEngine;
    using UnityEngine.SceneManagement;
    public class SceneLoader : MonoBehaviour
    {
    [SerializeField] float levelLoadDelay = 2f;
    private int currentSceneIndex = -1;
     public static SceneLoader instance;
    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    instance = this;
    }
    private void Start()
    {
        if (currentSceneIndex == 0)
        {
             Invoke("LoadFirstScene", 2f);
        }
    }
        public void LoadNextScene()
        {
            int currentSceneIndex =   SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
        public void LoadFirstScene()
        {
            SceneManager.LoadScene(1);
        }
 
