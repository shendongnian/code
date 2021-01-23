    [XmlRoot(Namespace="", ElementName="collection")]
    public class ConfigWrapper
    {
        [XmlElement("item")]
        public List<string> Items{ get; set;}
    }
