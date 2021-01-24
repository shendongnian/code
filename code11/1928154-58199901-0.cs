    [Serializable, XmlRoot("Config")]
    public class Config
    {
        public Interface Interface { get; set; }
        public Export Export { get; set; }
    }
    public struct Export
    {
        [XmlElement("Destination")]
        public List<string> Destinations { get; set; }
    }
