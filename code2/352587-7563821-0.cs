    [ServiceContract(CallbackContract = typeof(IService1Callback), SessionMode=SessionMode.Required)]
    public interface IService1
    {
        [OperationContract]
        void Process(string what);
    }
    public interface IService1Callback
    {
        [OperationContract]
        void Progress(string what, decimal percentDone);
    }
