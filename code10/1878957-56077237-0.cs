    [XmlRoot("DATA_SET")]
    public class QTMCollection
    {
        [XmlElement("DATA")]
        public List<QTM> QTMs { get; set; }
        [XmlAttribute("SampleSize")]
        public int SampleSize { get { return QTMs.Count; } set { return; } }        
    }
    
    public class QTM
    {
        [XmlAttribute]
        public int SampleId { get; set; }
        [XmlAttribute]
        public decimal IW { get; set; }
        [XmlAttribute]
        public decimal SL { get; set; }
        [XmlAttribute]
        public int PO { get; set; }        
    }
