    public class Properties
    {
        public string StoreCode { get; set; }
    }
    
    public class Response
    {
        public string Status { get; set; }
        public string Error { get; set; }
        public Dictionary<string, List<Properties>> Result { get; set; }
    }
