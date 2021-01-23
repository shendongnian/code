    public class Panel
    {
        [XmlArray(ElementName="panel")] //instead of [XmlArray(ElementName="tr")]
        [XmlArrayItem(ElementName="tr")]
        public List<tr> Tr { get; set; }
    .
    .
    }
