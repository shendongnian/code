    Method(RequestMessage request, OtherType value)
    // Your message contract much like this.
    [MessageContract]
    public class RequestMessage {
         [MessageBodyMember]
         public OtherType { get; set; }
    }
    // And your new method will be
    Method(RequestMessage request)
