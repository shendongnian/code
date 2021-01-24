    public class Details
    {
    	[JsonProperty("Harlson")]
        public string Harlson { get; set; }
    	[JsonProperty("adssd")]
        public string adssd { get; set; }
    	[JsonProperty("First Name")]
        public string FirstName { get; set; }
    	[JsonProperty("Last Name")]
        public string LastName { get; set; }
    }
    
    public class Contact
    {
        public int Source { get; set; }
        public int Id { get; set; }
        public Details Details { get; set; }
        public bool Pinned { get; set; }
    }
    
    public class Id
    {
        public List<Contact> Contacts { get; set; }
    }
    
    public class RootObject
    {
    	[JsonProperty("9002")]
        public Id Id { get; set; }
    }
