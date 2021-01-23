    [XmlType("doc"), XmlRoot("doc")]
    public class Document
    {
        public readonly List<Field> fields = new List<Field>();
        [XmlElement("field")]
        public List<Field> Fields { get { return fields; } }
    }
    [XmlType("field")]
    public class Field
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
