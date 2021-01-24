    public class JsonClass 
    {
        public JsonClass(){}
        public ResponseStatus status { get; set; }
        public IEnumerable<ResponseData> data {get; set;}
    }
    
    public class ResponseStatus
    {
        public ResponseStatus(){}
    
        public string type {get; set;}
        public int code {get; set;}
        public string message {get; set;}
        public bool error {get; set;}
    }
    
    public class ResponseData 
    {
        public string status {get; set;}
        public DateTime expires_at {get; set;}
        public ResponseUser user {get; set;}
        public string session_token {get; set;}
        public string return_to_url {get; set;}
    }
    
    public class ResponseUser 
    {
        public string username {get; set;}
        public string email {get; set;}
        public string firstname {get; set;}
        public string lastname {get; set;}
        public int id {get; set;}
    }
