    public class Panel
    {
        [XmlArray(ElementName="panel")]
        [XmlArrayItem(ElementName="tr")]
        public List<tr> Tr { get; set; }
    .
    .
    }
