    [SoapType(TypeName = "Map", Namespace = "http://xml.apache.org/xml-soap")]
    public class item
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string key { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string value { get; set; }
        [XmlArray("item")]
        [XmlArrayItem(typeof(item), ElementName = "item")]
        public item[] items { get; set; }
    }
