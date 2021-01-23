    public class Element
    {
        [XmlAttribute("published")]
        public bool Published { get; set; }
        [XmlAttribute("xml:lang", DataType = "language")]
        public string Language { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
