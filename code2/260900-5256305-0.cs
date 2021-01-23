    [XmlRoot("rundate")]
    public class RundateCollection
    {
        [XmlElement("rundateItem")]
        public List<rundate> Rundates { get; set; }
    }
