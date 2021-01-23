    [ServiceContract]
    public interface IPriceTesting
    {
        [OperationContract]
        decimal GetPrice(int productId);
    }
