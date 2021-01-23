    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        House GetHouse(int houseId);
    }
