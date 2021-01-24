    [ServiceContract]
    public interface IService1
    {
    
        [OperationContract]
        [WebGet]
        string GetData(int value);
