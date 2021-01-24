    public class HighScoreText : MonoBehaviour
    {
        Text text;
    
        // Start is called before the first frame update
        void Start()
        {
            Score.CheckForNewHighScore();
            int currentHighScore = Score.getHighScore();
            text = GetComponent<Text>();
            if(text != null) {
                 text.text = currentHighScore .ToString();
            }
        }
    
        // Update is called once per frame
        void Update()
        {
            // Removed everything from here because... well if they are 
            // on the gameover screen their score shouldn't increase 
            // So no reason to keep reseting the value.
        }
    }
