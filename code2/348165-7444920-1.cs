    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        BaseModel Get();
    }
