    [XmlRoot]
    public class MyXMLElement
    {
        [XmlAttribute]
        public string AnAttribute { get; set; }
    
        [XmlAttribute]
        public string AnotherElementAttribute { get; set; }
    
        [XmlText]
        public string InnerText { get; set; }
    }
