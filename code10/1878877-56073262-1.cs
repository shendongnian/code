    public class Value
    {
        public string url { get; set; }
    }
    
    public class Example
    {
        public string odata.metadata { get; set; }
        public IList<Value> value { get; set; }
    }
