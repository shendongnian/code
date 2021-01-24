    public class Scores
    {
        public IList<Level> Levels {get;}
        public Scores()
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
            Scores = new List<LevelScore>();
        }
    }
    
    public class LevelScore
    {
        public string User {get;set;}
        public string Score {get;set;}
    }
If in fact you really are only trying to track 2 fixed levels with the scores for 2 fixed users, your json should work with the initial class structure I presented.
