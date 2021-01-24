    [XmlRoot(Namespace ="urn:com.mysystems:api-message.002")]
    public partial class Request
    {
        public RequestHeader ReqHdr { get; set; }
    }
    public partial class RequestHeader
    {
        public string MsgId { get; set; }
    }
 
