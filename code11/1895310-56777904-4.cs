    using UnityEngine;
    using System.Collections.Generic;
    using System.Linq;
    public class HighscoreEntry
    {
        public int score;
        public string name;
    }
    public class OrderScores : MonoBehaviour
    {
        public List<HighscoreEntry> highScoreEntryList;
    
        public void Start()
        {
            highScoreEntryList = new List<HighscoreEntry>() {
                new HighscoreEntry{score = 1000, name = "Player5" },
                new HighscoreEntry{score = 1000, name = "Player1" },
                new HighscoreEntry{score = 2222, name = "Player4" },
                new HighscoreEntry{score = 2222, name = "Player2" },
                new HighscoreEntry{score = 1111, name = "Player3" },
                new HighscoreEntry{score = 3333, name = "Player6" }
            };
    
            List<HighscoreEntry> orderedRoundScores = OrderList(highScoreEntryList);
    
            foreach (HighscoreEntry entry in orderedRoundScores)
            {
                Debug.Log("Name: " + entry.name + ", Score: " + entry.score);
            }
    
            List<HighscoreEntry> scores = ScoresBasedOnPosition(orderedRoundScores);
    
    
            foreach (HighscoreEntry entry in scores)
            {
                Debug.Log("Name: " + entry.name + ", Score: " + entry.score);
            }
        }
    
        public List<HighscoreEntry> OrderList(List<HighscoreEntry> list)
        {
            list = list.OrderBy(o => o.name).ToList();
            list = list.OrderByDescending(o => o.score).ToList();
            return list;
        }
        
        public List<HighscoreEntry> ScoresBasedOnPosition(List<HighscoreEntry> allPlayers)
        {
            int[] positionRelatedScores = new int[] { 125, 75, 50, 25, 10 }; 
            int currentPositionRelatedScoresIndex = 0;
    
            List<HighscoreEntry> scoresBasedOnPositionList = new List<HighscoreEntry>(); 
    
            int previousScore = -1; 
    
            for (int x = 0; x < allPlayers.Count; x++)
            {
                int playerScore = allPlayers[x].score; 
    
                if (x > 0 && previousScore != playerScore)
                {
                    currentPositionRelatedScoresIndex++;
                    if (currentPositionRelatedScoresIndex >= positionRelatedScores.Length)
                    {
                        break;
                    }
                }
    
                scoresBasedOnPositionList.Add( new HighscoreEntry { name = allPlayers[x].name, score = positionRelatedScores[currentPositionRelatedScoresIndex]});
    
                previousScore = playerScore; 
            }
    
            return scoresBasedOnPositionList;
        }
    
    }
