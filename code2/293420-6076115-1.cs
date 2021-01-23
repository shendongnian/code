    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        public bool CheckCustomerExists(Customer Customer);
    }
