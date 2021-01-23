    [Serializable]
    [XmlRoot("Fields")]
    public class FieldCollection
    {
        [XmlAttribute("lang")]
        public string Lanuage { get; set; }
        [XmlElement("Item")]
        public FieldTranslation[] Fields { get; set; }
    }
    [Serializable]
    public class FieldTranslation
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        public string Tooltip { get; set; }
        public string Label { get; set; }
        public string Error { get; set; }
        public string Language { get; set; }
    }
