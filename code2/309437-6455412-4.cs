    public class bookingList
    {
        [XmlElement(Order = 1)]
        public string error { get; set; }
        [XmlElement(Order = 2)]
        public int counter { get; set; }
        [XmlElement(ElementName = "booking", Order = 3)]
        public List<booking> bookings = new List<booking>();
    }
    
    public class booking
    {
        public int id { get; set; }
    }
