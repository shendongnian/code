     public class Accommodations
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LocationID { get; set; }
        [ForeignKey("LocationID")]
        public Location Location { get; set; }
    }
    public class Location
    {
        public int ID { get; set; }
        public string Address { get; set; }
        //other stuff you want
    }
