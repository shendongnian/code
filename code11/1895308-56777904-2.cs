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
    
            List<HighscoreEntry> orderedList = OrderList(highScoreEntryList);
            foreach (HighscoreEntry entry in orderedList)
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
        
    }
