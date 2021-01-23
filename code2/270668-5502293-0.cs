    public class Response {
    
        public string id { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string timestamp { get; set; }
        public User user { get; set; }
    
    }
    
    public class User {
    
        public int id { get; set; }
        public string screen_name { get; set; }
    
    }
