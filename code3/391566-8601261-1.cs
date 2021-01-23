    [XmlRoot("CallConnectReq")]
    public class CallConnectRequest {
        [XmlAttribute("Xmlns"), Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlNamespace {
            get { return "urn:interno-com:ns:a9c";} set { }
        }
        [XmlAttribute("reqId")]
        public int RequestId { get; set; }
        [XmlAttribute("msbNb")]
        public int MessageNumber { get; set; }
        [XmlElement("LocalCallId")]
        public int LocalCallId { get; set; }
    }
