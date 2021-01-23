    public class XurrencyResponse {
        public class Result {
            public string updated_at {get;set;}
            public decimal value {get;set;}
            public string target {get;set;}
            public string base {get;set;}
        }
        public Result result {get;set;}
        public int code {get;set;}
        public string status {get;set;}
    }
