    public class Score
    {
        public string user {get;set;}
        public string score {get;set;}
    }
    public class Level
    {
        public string name {get;set;}
        public IList<Score> scores {get;}
        public Level()
        {
            scores = new List<Score>();
        }
    }
    public class RootObject
    {
        public IList<Level> levels {get;}
        public RootObject()
        {
            levels = new List<Level>();
        }
    }
If in fact you really are only trying to track 2 fixed levels with the scores for 2 fixed users, your json should work with the initial class structure I presented.
