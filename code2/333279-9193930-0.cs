    public class Country
    {
        public string Name { get; set; }
        public int Population { get; set; }
    }
    
    public class Continent
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public IList<Country> Countries { get; set; }
    }
