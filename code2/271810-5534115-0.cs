    [ServiceContract]
    public interface IEcho
    {
        [OperationContract]
        string SendEcho(string Message);
    }
