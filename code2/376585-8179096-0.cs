    public class Request {
        [XmlAttribute] public string Type {get;set;}
        [XmlAttribute] public string CRUD {get;set;} // although I'd prefer an enum
        
        public RequestUser Users {get;set;}
    }
    public class RequestUser {
        public string UserName {get;set;}
        public string Password {get;set;} // please use salted hash instead
    }
