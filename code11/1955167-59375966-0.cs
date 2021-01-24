    [XmlRoot(ElementName = "DATAPACKET")]
    public class DATAPACKET
    {
        [XmlElement(ElementName = "METADATA")]
        public METADATA METADATA { get; set; }
        [XmlElement(ElementName = "ROWDATA")]
        public ROWDATA ROWDATA { get; set; }
        [XmlAttribute(AttributeName = "Version")]
        public string Version { get; set; }
    }
    [XmlRoot(ElementName = "FIELD")]
    public class FIELD
    {
        [XmlAttribute(AttributeName = "attrname")]
        public string Attrname { get; set; }
        [XmlAttribute(AttributeName = "fieldtype")]
        public string Fieldtype { get; set; }
        [XmlAttribute(AttributeName = "WIDTH")]
        public string WIDTH { get; set; }
    }
    [XmlRoot(ElementName = "FIELDS")]
    public class FIELDS
    {
        [XmlElement(ElementName = "FIELD")]
        public List<FIELD> FIELD { get; set; }
    }
    [XmlRoot(ElementName = "METADATA")]
    public class METADATA
    {
        [XmlElement(ElementName = "FIELDS")]
        public FIELDS FIELDS { get; set; }
        [XmlElement(ElementName = "PARAMS")]
        public string PARAMS { get; set; }
    }
    [XmlRoot(ElementName = "ROW")]
    public class ROW
    {
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "NAME")]
        public string NAME { get; set; }
    }
    [XmlRoot(ElementName = "ROWDATA")]
    public class ROWDATA
    {
        [XmlElement(ElementName = "ROW")]
        public List<ROW> ROW { get; set; }
    }
