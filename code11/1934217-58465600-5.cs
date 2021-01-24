    public class MainMenuController : MonoBehaviour
    {  
     [SerializeField] Text bestScoreText;
     [SerializeField] Toggle soundToggle;
     public GameObject gameManager;
     
     private void OnEnable()
     {
         Init();
     }
     private void Init()
     {
    	if (GameManager.instance == null){
    		Debug.Log("null game manager");
    		Instantiate(gameManager);
    	} 
        gameManager.playerLives = 0;
        //...
     }
    }
