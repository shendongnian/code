    public interface IQueueService
    {
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Connect(MessageBase message);
        [OperationContract]
        UserBase LoginUser(string userName, string password);
        [OperationContract]
        bool LogoutUser(string userName);
        [OperationContract(IsOneWay = false, IsTerminating = true)]
        void Disconnect();
    }
