    public class Result
    {
        public string Id { get; set; }
        public string Version { get; set; }
    }
    
    public class D
    {
        public List<Result> results { get; set; }
        public int count { get; set; }
    }
    
    public class RootObject
    {
        public D d { get; set; }
    }
