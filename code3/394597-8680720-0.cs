    [MessageContract(IsWrapped = false)]
    public class OTA_CancelRQMessage
    {
        [MessageBodyMember]
        public void OTA_CancelRQ { get; set; }
    }
    [MessageContract(IsWrapped = false)]
    public class OTA_CancelRSMessage
    {
        [MessageBodyMember]
        public void OTA_CancelRS { get; set; }
    }
    [ServiceContract]
    [XmlSerializerFormat]
    public interface IEBooking10
    {
       [OperationContract]
       [XmlSerializerFormat]
       OTA_CancelRSMessage OTA_Cancel(OTA_CancelRQMessage rq);
    }
