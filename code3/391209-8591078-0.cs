    [XmlRoot("Schedule")]
    public class ParserSchedule
    {
        [XmlElement("ParserMonth")]
        public ParserMonth[] Months { get; set; } 
    }
    public class ParserMonth
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("ParserDay")]
        public ParserDay[] Days { get; set; } 
    }
    public class ParserDay
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
