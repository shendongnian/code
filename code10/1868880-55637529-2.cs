    public class Scores
    {
        public IList<Level> Levels {get;set;}
    }
    
    public class Level
    {
        public string Name {get;set;}
        public List<LevelScore> Scores {get;set;}
    }
    
    public class LevelScore
    {
        public string User {get;set;}
        public string Score {get;set;}
    }
