    public class CoinScript : MonoBehaviour
    {
    
    public int coinValue;
    private LevelManager gameLevelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other) {
    	Debug.Log("Triggered");
        if (other.tag == "Player")
        {
            gameLevelManager.AddCoins(coinValue);
            Destroy(gameObject);
        }
    	
    }
    
    }
