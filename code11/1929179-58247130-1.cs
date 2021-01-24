    public class Filter
    {
        public string andOr { get; set; }
        public bool openCondition { get; set; }
        public string columnName { get; set; }
        public string @operator { get; set; }
        public string value { get; set; }
        public bool closeCondition { get; set; }
    }
    
    public class Sort
    {
        [JsonExtensionData]
    	public Dictionary<string,object> RandomKeyValuePair {get;set;}
    }
    
    public class RootObject
    {
        public List<Filter> filter { get; set; }
        public Sort sort { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
