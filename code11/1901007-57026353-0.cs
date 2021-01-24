    using UnityEngine;
    using UnityEngine.SceneManagement;
    public class GMScript : MonoBehaviour
    {
        private static GMScript instance;
        private void Awake()
        {
            if (instance == null || instance == this)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this);
            Debug.Log("Scene reloaded");
        }
        public void ReloadScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                ReloadScene();
            }
        }
    }
