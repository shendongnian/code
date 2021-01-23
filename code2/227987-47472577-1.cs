    [MessageContract]
    public class CallRequestMessage
    {
        [MessageHeader]
        public string Arg1;
        [MessageHeader]
        public int ParametersLen;
        [MessageBodyMember]
        public Stream Parameters;
    }
    [MessageContract]
    public class CallResponceMessage
    {
        [MessageHeader]
        public int ResultCode;
        [MessageHeader]
        public int ResultsLen;
        [MessageBodyMember]
        public Stream Results;
    }
    [ServiceContract]
    public interface ILocalServiceAPI
    {
        [OperationContract]
        CallResponceMessage Call(CallRequestMessage message);
    }
