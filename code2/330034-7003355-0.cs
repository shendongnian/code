    public class Event
    {
        [Key]
        public long id { get; set; }          
        public string title { get; set; }
        public string description { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public int importance { get; set; }
        public virtual Calendar Calendar { get; set; }
        public int CalendarId { get; set; }
    } //class
