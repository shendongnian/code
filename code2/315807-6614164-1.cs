    public class Activity
    {
        public int ID {get;set;}
        public string Personnel { get; set; }
        [ForeignKey("Location")]
        public string LocationName { get; set; }
        public Location Location { get; set; }
    }
