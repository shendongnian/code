    [DataContract]
    public class MessageV2 : Message
    {
        [DataMember]
        public DateTime Sent {get; set;}
    }
