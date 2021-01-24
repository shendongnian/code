    public class Price
    {
        public double pricePerMessage { get; set; }
        public string currency { get; set; }
    }
    
    public class Status
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
    
    public class Error
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool permanent { get; set; }
    }
    
    public class Result
    {
        public string messageId { get; set; }
        public string to { get; set; }
        public string from { get; set; }
        public DateTime sentAt { get; set; }
        public DateTime doneAt { get; set; }
        public int smsCount { get; set; }
        public string mccMnc { get; set; }
        public Price price { get; set; }
        public Status status { get; set; }
        public Error error { get; set; }
    }
    
    public class RootObject
    {
        public List<Result> results { get; set; }
    }
