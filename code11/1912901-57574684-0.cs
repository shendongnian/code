    [Serializable]
    [XmlRoot("LIBRARY")]
    public class LibraryCollection
    {
        [System.Xml.Serialization.XmlElement("FLOOR")]
        public Floor Floor { get; set; }
    }
    [Serializable]
    public class Floor
    {
        [XmlElement("BK01")]
        public BK Bk01 { get; set; }
        [XmlElement("BK02")]
        public BK Bk02 { get; set; }
    }
    [Serializable]
    public class BK
    {
        [XmlAttribute("Value")]
        public string Value { get; set; }
    }
