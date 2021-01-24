    public class GameControl : MonoBehaviour
    {
        public static GameControl instance;
    
        public int score = 5;
    
        void Start()
        {   
            // Store the value 
            GameControlMenu.StuffToShowOnScoreText = "PREVIOUS SCORE: " + score;
        }
    }
