    [XmlRoot(ElementName = "GroupSet", Namespace = "http://abc.def.schema")]
    public class GroupSet
    {
        [XmlElement(ElementName = "staticGroup", Namespace = "")]
        public List<StaticGroup> StaticGroup { get; set; }
    }
