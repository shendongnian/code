    public class Domain
    {
        public int id { get; set; }
        public string domainTitle { get; set; }
        public bool isDeleted { get; set; }
    }
    
    public class Result
    {
        public string status { get; set; }
        public List<Datum> data { get; set; }
    }
    var returnData = JsonConvert.DeserializeObject<Result>(...);
