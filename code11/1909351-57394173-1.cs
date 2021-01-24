    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
        [XmlElement(ElementName = "GroupSet", Namespace = "http://abc.def.schema")]
        public GroupSet GroupSet { get; set; }
    }
