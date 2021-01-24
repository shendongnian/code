        [XmlRoot(ElementName = "Receiver", Namespace = "al:2.0.0")]
    public class Receiver
    {
        [XmlElement(ElementName = "ANumberIdentificator", Namespace = "al:1.0.0")]
        public List<string> ANumberIdentificator { get; set; }
        [XmlElement(ElementName = "BNumberIdentificator", Namespace = "al:1.0.0")]
        public List<string> BNumberIdentificator { get; set; }
    }
    [XmlRoot(ElementName = "DispatchReceiverGroup", Namespace = "al:1.0.0")]
    public class DispatchReceiverGroup
    {
        [XmlElement(ElementName = "Receiver", Namespace = "al:2.0.0")]
        public Receiver Receiver { get; set; }
    }
    [XmlRoot(ElementName = "Dispatch", Namespace = "al:2.0.0")]
    public class Dispatch
    {
        [XmlElement(ElementName = "MsgIdentificator", Namespace = "al:2.0.0")]
        public string MsgIdentificator { get; set; }
        [XmlElement(ElementName = "DispatchReceiverGroup", Namespace = "al:1.0.0")]
        public DispatchReceiverGroup DispatchReceiverGroup { get; set; }
        [XmlAttribute(AttributeName = "al1", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Al1 { get; set; }
        [XmlAttribute(AttributeName = "al2", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Al2 { get; set; }
    }
