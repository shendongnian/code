    public class RateLimit
    {
        public int limit { get; set; }
        public int remaining { get; set; }
        public int reset { get; set; }
    }
    public class Meta
    {
        public bool success { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public int totalCount { get; set; }
        public int pageCount { get; set; }
        public int currentPage { get; set; }
        public int perPage { get; set; }
        public RateLimit rateLimit { get; set; }
    }
    public class Self
    {
        public string href { get; set; }
    }
    public class Edit
    {
        public string href { get; set; }
    }
    public class Avatar
    {
        public string href { get; set; }
    }
    public class Links
    {
        public Self self { get; set; }
        public Edit edit { get; set; }
        public Avatar avatar { get; set; }
    }
    public class Result
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public Links _links { get; set; }
    }
    public class RootObject
    {
        public Meta _meta { get; set; }
        public List<Result> result { get; set; }
    }
