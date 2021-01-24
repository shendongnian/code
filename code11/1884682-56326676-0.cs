    [XmlRoot(ElementName="Stops")]
    public class Stops {
        [XmlElement(ElementName="Stop")]
        public List<Stop> Stop { get; set; }
    }
