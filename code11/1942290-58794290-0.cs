    public class StatMetaData
    {
        public string key { get; set; }
        public string name { get; set; }
        public string categoryKey { get; set; }
        public string categoryName { get; set; }
        public bool isReversed { get; set; }
    }
    
    public class Stat
    {
        public StatMetaData metadata { get; set; }
        public double value { get; set; }
        public double percentile { get; set; }
        public string displayValue { get; set; }
        public string displayRank { get; set; }
    }
    
    public class Data
    {
        public List<Stat> stats { get; set; }
    }
    
    public class RootObject
    {
        public Data data { get; set; }
    }
