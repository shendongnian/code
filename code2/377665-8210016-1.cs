    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        void Method1();
        [OperationContract]
        string Method2(int someValue);
        // and so on
    }
