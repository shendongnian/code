    [XmlRoot]
    public class Root
    {
        [XmlArray("groups")]
        [XmlArrayItem("group")]
        public List<Group> Groups { get; set; }
    }
    [XmlType]
    public class Group
    {
    }
