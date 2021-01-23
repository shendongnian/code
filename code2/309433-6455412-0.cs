    public class bookingList
    {
        public string error { get; set; }
        public int counter { get; set; }
        [XmlElement(ElementName = "booking")]
        public List<booking> bookings = new List<booking>();
    }
    
    public class booking
    {
        public int id { get; set; }
    }
