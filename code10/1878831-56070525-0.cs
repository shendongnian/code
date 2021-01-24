    public class Level
    {
        public TimeSpan TimeTaken { get; set; }
        // level specific data
    }
    
    public class City
    {
        public IList<Level> Levels { get; set; }
    }
    
    public class Country
    {
        public IList<City> Cities { get; set; }
    }
