    public class PlayerControllerb : MonoBehaviour
    {
        [Header("Debug")]
        [SerializeField] private PlatformProvider platformProvider;
        private void Awake ()
        {
            OnSceneLoaded();
            SceneManager.onSceneLoaded -= OnSceneLoaded;
            SceneManager.onSceneLoaded += OnSceneLoaded;
        }
    
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // If anyway there is a new PlayerControllerb on each scene 
            // remove Awake and OnSceneLoaded and simply set the reference in the Inspector.
            platformProvider = FindObjectOfType<PlatformProvider>();
        }
