    [DataContract]
    public class Response{
        [DataMember]
        public string responseCode {get;set;}
        [DataMember]
        public string responseMessage {get;set;}
        [DataMember]
        public ResponseBody responseBody {get;set;}
    }
    
