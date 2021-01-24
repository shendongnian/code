    public class Activity
    {
        public int ActivityID { get; set; }
        public string Version{ get; set; }
        public DateTime Date { get; set; }
        public string Changes { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }  // navigation property for User
        public int SystemID { get; set; }
        public System System { get; set; }  // navigation property for System
    }
