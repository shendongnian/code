    [GeneratedCode("xsd", "4.0.30319.1")]
    [DebuggerStepThrough]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "NSArray", Namespace = "", IsNullable = false)]
    [Serializable]
    public class SearchResult
    {
        [XmlElement("Song", Form = XmlSchemaForm.Unqualified)]
        public Song[] Items { get; set; }
    }
    [GeneratedCode("xsd", "4.0.30319.1")]
    [DebuggerStepThrough]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName="Song", Namespace = "", IsNullable = false)]
    [Serializable]
    public class Song
    {
        [XmlElement("title", Form = XmlSchemaForm.Unqualified)]
        public string Title { get; set; }
        [XmlElement("artist", Form = XmlSchemaForm.Unqualified)]
        public Artist Artist { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
    [GeneratedCode("xsd", "4.0.30319.1")]
    [DebuggerStepThrough]
    [XmlType(AnonymousType = true)]
    [Serializable]
    public class Artist
    {
        [XmlElement("nameWithoutThePrefix", Form = XmlSchemaForm.Unqualified)]
        public string NameWithoutThePrefix { get; set; }
        [XmlElement("useThePrefix", Form = XmlSchemaForm.Unqualified)]
        public string UseThePrefix { get; set; }
        [XmlElement("name", Form = XmlSchemaForm.Unqualified)]
        public string Name { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
