    public class Music : MonoBehaviour
    {
        public AudioSource music;
        public string loadLevel;
        public float fadeOutTime = 3f;
    
        private static Music _instance;
        void Awake()
        {
            DontDestroyOnLoad(music.gameObject);
            // If necessary use a singleton pattern to make sure this exists only once
            if(_instance)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            // Also don't destroy yourself!
            DontDestroyOnLoad(gameObject);
    
            // Just to be sure before adding a callback you should always remove it
            // This is valid even if it wasn't added yet
            // but it makes sure it is only added exactly once
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    
        void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    
        private IEnumerator FadeOutAndDestroy()
        {
            var fadePerSec = music.volume / fadeOutTime;
            while(music.volume > 0)
            {
                music.volume = Mathf.MoveTowards(music.volume, 0, fadePerSec * Time.deltaTime);
                
                // yield says: Interupt the routine here, render this frame
                // and continue from here in the next frame
                // In other words: Coroutines are like small temporary Update methods
                yield return null;
            }
    
            // Now the volume is 0
            Destroy(music.gameObject);
    
            // and since no longer needed also destroy this object
            Destroy(gameObject);
        }
    
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.buildIndex != 7) return;
            
            StartCoroutine(FadeOutAndDestroy());
        }
    }
