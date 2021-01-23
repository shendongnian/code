    public class Data
    {
        [XmlIgnore]
        public bool CLS_CDSpecified { get; set; }
        [XmlElement(IsNullable=true)]
        public string CLS_CD { get; set; }
    }
