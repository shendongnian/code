    public class Cars
    {
        [XmlElement("car")]
        public Car[] Items { get; set; }
    
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
