    public class CoinManager : MonoBehaviour
    {
        private Camera camera;
        [SerializeField] private AudioClip coinCollectedSound;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private List<CoinScript> coins;
        [SerializeField] private int coinCount;
        [SerializeField] private Text coinLabel;
    
        // This could be called by some spawner class that
        // adds coins to the scene
        public void AddCoin(CoinScript coin)
        {
            coins.Add(coin);
        }
    
    
        public void CoinCollected(CoinScript coin)
        {
            Destroy(coin.gameObject);
            coinCount++;
            audioSource.PlayOneShot(coinCollectedSound);
            // Alternatively, if you have a dedicated audio source 
            // for coin sounds you can just use audioSource.Play();
        }
    
        private void Update()
        {
            // Iterate over all the coins we know about
            foreach (var coin in coins)
            {
                // Now that we have a method that tells us whether a
                // coin is on the screen or not, we can enable and disable
                // all the coins at the same time in one place
                coin.transform.enabled = IsOnScreen(coin.transform.position);
            }
        }
    
        private void Awake()
        {
            // Gets the main camera in the scene
            // https://docs.unity3d.com/ScriptReference/Camera-main.html
            camera = Camera.main;
            coins = new List<CoinScript>();
        }
    
        private bool IsOnScreen(Vector3 worldPosition)
        {
            Vector3 screenPoint = camera.WorldToViewportPoint(worldPosition);
    
            return screenPoint.x > 0
                   && screenPoint.x < 1
                   && screenPoint.y > 0
                   && screenPoint.y < 1;
        }
    }
