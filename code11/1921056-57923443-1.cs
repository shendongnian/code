    public List<ScoreEntry> scoreBoard = new List<ScoreEntry>();
    [Serializable]
    public class ScoreEntry
    {
        public string Name;
        // or still string if you want to stick to that
        public int Score;
        public ScoreEntry(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
    
