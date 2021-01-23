     public class Session
    {
        public int id { get; set; }
        public long ip { get; set; }      
        public User User {get;set;}
    }
    public class User
    {
        [Key]
        public int id { get; set; }
        public long ip { get; set; }
        public string name { get; set; }
        public ICollection<Session> sessions { get; set; }
    }
