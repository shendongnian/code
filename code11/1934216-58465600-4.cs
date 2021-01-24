    public class GameManager : MonoBehaviour
    {
       public static GameManager instance = null;
    
       // Change this to public to access from the other script
       public int levelIndex;
       public int gameScore;   
       public int playerLives;
    
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
