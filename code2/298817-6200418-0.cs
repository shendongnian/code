    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate="customers/{id}", ResponseFormat=WebMessageFormat.Json)]
        Customer GetCustomer(string id);
        [OperationContract]
        [WebInvoke(UriTemplate="customers", ResponseFormat=WebMessageFormat.Json)]
        Customer PostCustomer(Customer c);
    }
