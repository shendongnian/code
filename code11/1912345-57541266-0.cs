    public class GameControlMenu : MonoBehaviour
    {
    
        public static GameControlMenu instanceMenu;
    
        public static string StuffToShowOnScoreText { get; set; }
    
        public Text scoreText;
    
        void Awake()
        {
            // So that it loads the text on start
            scoreText.text = StuffToShowOnScoreText;
            // ...
        }
    }
