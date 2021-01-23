    [XmlRoot("Responses")]
    public class TxTNotifyResponse : DataContainer
    {
        [XmlArray("ResponseList")]
        [XmlArrayItem("Response")]
        public MsgResponseCollection MsgResponseList { get; set; }
    }
    
    public class MsgResponse : DataContainer 
    {
        [XmlElement("Foo")]
        public string Status { get; set; }
        [XmlElement("Bar")]
        public string MessageId { get; set; }
    }
    
    public class MsgResponseCollection : List<MsgResponse>
    {
    }
