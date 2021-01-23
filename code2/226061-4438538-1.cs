    [XmlType("add"), XmlRoot("add")]
    public class WhateverAddIs {
        private readonly List<Document> docs = new List<Document>();
        [XmlElement("doc")]
        public List<Document> Documents { get { return docs; } }
    }
    public class Document {
        private readonly List<Field> fields = new List<Field>();
        [XmlElement("field")]
        public List<Field> Fields { get { return fields; } }
    }
    public class Field {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
