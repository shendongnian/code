    public class data
    {
        public string id { get; set; }
        [XmlElement(ElementName = "property")]
        public List<property> lista { get; set; }
    }
    public class property
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlText( typeof(string))]
        public string value { get; set; }
    }
