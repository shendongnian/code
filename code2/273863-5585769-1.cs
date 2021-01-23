    public class Element
    {
        [XmlAttribute("published")]
        public bool Published { get; set; }
        [XmlAttribute("lang", 
            Namespace="http://www.w3.org/XML/1998/namespace",
            DataType = "language")]
        public string Language { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
