    [ServiceContract]
    public interface IEcho
    {
        [OperationContract]
        string SendEcho(Message message);
    }
    [DataContract]
    public class Message
    {
        [DataMember]
        public string Message {get; set;}
    }
