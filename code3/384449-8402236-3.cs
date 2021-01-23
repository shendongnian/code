    public class Account {
        [XmlAttribute("ID")]
        public string Id { get; set; }
        [XmlElement("stuff")]
        public StuffType Stuff { get; set; }
        // ... and so on
    }
