    [XmlRoot(Namespace = "http://www.w3.org/2005/Atom")]
    public class feed
    {
        [XmlElement("link")]
        public link[] link { get; set; }
    }
    public class link
    {
        [XmlAttribute]
        public string type { get; set; }
        [XmlAttribute]
        public string rel { get; set; }
        [XmlAttribute]
        public string href { get; set; }
    }
