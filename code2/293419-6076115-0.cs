    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        public string Customer(string Name);
    }
