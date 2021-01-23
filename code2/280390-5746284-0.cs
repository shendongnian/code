    [XmlRoot("reply")]
    public class Reply
    {
        [XmlElement("result")]
        public string Result { get; set; }
        [XmlElement("code")]
        public int Code { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
    }
