    public class UnitySingleton : MonoBehaviour
    {
        public static UnitySingleton Instance { get; private set; }
    
        public int Score { get; set; }
    
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
