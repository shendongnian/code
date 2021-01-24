    [XmlRoot(ElementName = "Envelope")]
    public class Envelope
    {
        [XmlElement(ElementName = "Header")]
        public Header Header { get; set; }
        [XmlElement(ElementName = "Body")]
        public Body Body { get; set; }
    }
    
    [XmlRoot(ElementName = "Body")]
    public class Body
    {
        [XmlElement(ElementName = "Request")]
        public Request Request { get; set; }
    }
