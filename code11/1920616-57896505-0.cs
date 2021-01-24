    [XmlRoot(ElementName = "BodyTest")]
    public class BodyTest
    {
        [XmlArray("ProjectTests")]
        [XmlArrayItemAttribute("ProjectT", Namespace = "https://example.com/schemas", IsNullable = false)]
        public HashSet<ProjectT> ProjectTests { get; set; }
    }
