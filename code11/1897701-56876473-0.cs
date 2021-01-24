        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using UnityEngine.UI;
    
        public class ScoreScript : MonoBehaviour {
    
            public static int scoreValue = 0;
            public Text score;
            public Text highScoreText;
            public static int highscore;
    
            void Start () {
                highscore = PlayerPrefs.GetInt("HighScore", 0);
                highScoreText.Text = "" + highScore;
                score = GetComponent<Text>();
                scoreValue = 0;
            }
        
            void Update () {
                score.text = "" + scoreValue;
            }
        }
