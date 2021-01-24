    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class Score : MonoBehaviour
    {
        public int score;
        public Text ScoreText;
        public int highscore;
        public Text highScoreText;
    
    
        void Start()
        {               
            highscore = HighestScoreJson.GetHighestScore().highestScore; 
        }
    
        void Update()
        {
            ScoreText.text = "Score: " + score;
            highScoreText.text = highscore.ToString();
            if (score > highscore)
            {
                highscore = score;
            HighestScoreJson.SaveHighestScore(highscore);
            }
        }
        void OnTriggerEnter(Collider other)
        {
            Debug.Log("collider is working");
            if (other.gameObject.tag == "Score: ")
            {
                score++;
            }
        }
    
    }
