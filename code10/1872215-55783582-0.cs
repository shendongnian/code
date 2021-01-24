    public class Name
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
    
    public class Email
    {
        public string value { get; set; }
    }
    
    public class DaPOCO
    {
        public Name name { get; set; }
        public List<Email> emails { get; set; }
    }
