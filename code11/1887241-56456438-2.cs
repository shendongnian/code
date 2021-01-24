    public class Params
    {
        public string cnt { get; set; }
        public string lastGlobalMessageTime { get; set; }
        public int lastId { get; set; }
    }
    
    public class RootObject
    {
        public string __invalid_name__social[google-login] { get; set; }
        public string action { get; set; }
        public Params @params { get; set; }
        public string session { get; set; }
    }
