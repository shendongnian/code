    [XmlRoot("ChatXMLResult")] 
    public class Chat
    {
        [XmlElement("Signature")] // optional 
        public string Signature { get; set; }
        [XmlArray("FilteredResultSet")]
        public Message[] FilteredResult { get; set; }
    }
