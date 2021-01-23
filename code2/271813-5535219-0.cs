    [ServiceContract]
    public interface IEcho
    {
        [OperationContract]
        void SetMessage(string message);
        [OperationContract]
        string GetMessage();
        ... etc ...
    }
