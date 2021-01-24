    public class ARRAY
    {
        public string Item1 { get; set; }
        public string Item2 { get; set; }
    }
    public class Result
    {
        public int ID { get; set; }
        public string TITLE { get; set; }
        public List<ARRAY> ARRAY { get; set; }
    }
    public class BaseResult
    {
        public Result result { get; set; }
    }
