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
            platformProvider = FindObjectOfType<PlatformProvider>();
        }
