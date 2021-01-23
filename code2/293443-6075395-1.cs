    [XmlRoot("ChatXMLResult")] 
    public class Chat
    {
        [XmlElement("Signature")] // optional 
        public string Signature { get; set; }
        [XmlArray("Messages")]
        public Message[] Messages { get; set; }
    }
