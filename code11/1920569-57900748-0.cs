    public class Report
    {     
        public string itemname { get; set; }
        public List<itemlocation> locations { get; set; }
    }
    public class itemlocation
    {
        public string location { get; set; }
        public List<items> items { get; set; }
        public string assignedworker { get; set; }
    }
    public class items
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
