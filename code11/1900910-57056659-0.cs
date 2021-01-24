    [ServiceContract]
    public interface IServices
    {
        [OperationContract]
        string GetInformationB(ClassB objectB);
       [OperationContract]
        string GetInformationC(ClassC objectC);
       [OperationContract]
        string GetInformationD(ClassD objectD);
    }
