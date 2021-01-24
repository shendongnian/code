    [DataContract]
    [KnownType(typeof(OriginalConfirmRequest))]
    [KnownType(typeof(OriginalLoadRequest))]
    [KnownType(typeof(OriginalRedeemRequest))]
    [KnownType(typeof(OriginalVoidRequest))]
    public class OriginalRequest
    {
        [DataMember]
        public MessageHeader MsgHeader { get; set; }
    }
