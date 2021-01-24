    using UnityEngine;
    public class UsageScript: MonoBehaviour { 
        private SceneManager SceneManager;
        void Awake ()
        {
            sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        }
 
        void UsageManager()
        {
            sceneManager.SaveScene();
 
            sceneManager.LoadScene();
        }
    }
