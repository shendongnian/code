    public class XurrencyResponse
    {
        public string Status { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public Result Result { get; set; }
    }
    
    public class Result
    {
        public decimal Value { get; set; }
        public string Target { get; set; }
        public string Base { get; set; }
        public DateTime Updated_At { get; set; }
    }
