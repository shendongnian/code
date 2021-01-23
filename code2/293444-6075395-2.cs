    [XmlRoot("ChatXMLResult")] 
    public class Chat
    {
        [XmlElement("Signature")] // optional 
        public string Signature { get; set; }
        [XmlArray]
        [XmlArrayItem(typeof(Message), ElementName="Message")]
        public Message[] Messages { get; set; }
    }
    public class Message { .. }
