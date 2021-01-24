    public class GameManager : MonoBehaviour
    {
       public static GameManager instance = null;
    
       private int levelIndex;
       private int gameScore;   
       private int playerLives;
    
       void Awake()
       {
    		if(instance == null)
    			instance = this;
    		else if (instance != this)
    	        Destroy(gameObject);
    			
    		// To keep this objectr from one scene to the next one		
    		DontDestryOnLoad(gameObject)
       }
    }
