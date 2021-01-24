    [XmlRoot(ElementName = "data")]
    public class Data
    {
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "raID")]
        public string RaID { get; set; }
        [XmlAttribute(AttributeName = "ratext")]
        public string Ratext { get; set; }
    }
    
    [XmlRoot(ElementName = "ReportAddendum")]
    public class ReportAddendum
    {
        [XmlElement(ElementName = "data")]
        public Data Data { get; set; }
    }
    
    [XmlRoot(ElementName = "Report")]
    public class Report
    {
        [XmlElement(ElementName = "data")]
        public Data Data { get; set; }
        [XmlElement(ElementName = "ReportAddendum")]
        public List<ReportAddendum> ReportAddendum { get; set; }
    }
    
    [XmlRoot(ElementName = "Reports")]
    public class Reports
    {
        [XmlElement(ElementName = "Report")]
        public Report Report { get; set; }
    }
