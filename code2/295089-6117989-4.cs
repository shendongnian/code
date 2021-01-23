    public class Scrilla
    {
        // the parts that get serialized:
        [XmlElement]
        public String Name { get;set; }
        [XmlElement]
        public DateTime FirstReport { get;set; }
        [XmlElement]
        public String MoreInfo { get;set; }
    }
