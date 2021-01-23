    [XmlRoot("msg")]
    public class Message
    {
        [XmlElement("reply")]
        public MessageReply Reply { get; set; }
    }
