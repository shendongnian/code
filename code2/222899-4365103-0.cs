    [XmlRoot]
    public class Header
    {
        [XmlElement]
        public Version Version { get; set; }
    }
    public class Version
    {
        [XmlAttribute("environment")]
        public String Environment { get; set; }
        [XmlText]
        public String Value { get; set; }
    }
