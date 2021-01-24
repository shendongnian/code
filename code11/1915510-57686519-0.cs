    public class Alternative
    {
        public string transcript { get; set; }
        public double confidence { get; set; }
    }
    
    public class Result
    {
        public List<Alternative> alternatives { get; set; }
    }
    
    public class RootObject
    {
        public List<Result> results { get; set; }
    }
