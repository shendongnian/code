    public class HighScores
    {
        public IList<Level> Levels {get;}
        public HighScores()
        {
            Levels = new List<Level>();
        }
    }
    
    public class Level
    {
        public string Name {get;set;}
        public IList<LevelScore> Scores {get;}
        public Level()
        {
            Scores = new List<HighScore>();
        }
    }
    
    public class HighScore
    {
        public string User {get;set;}
        public string Score {get;set;}
    }
If in fact you really are only trying to track 2 fixed levels with the scores for 2 fixed users, your json should work with the initial class structure I presented.
