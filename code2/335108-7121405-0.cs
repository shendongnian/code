    [DataContract]
    public sealed class CustomerResponse
    {
        [DataMember]
        public Guid CustomerReference { get; set; }
    }
    [ServiceContract]
    public interface IWcfMessagingService
    {
        [OperationContract]
        CustomerResponse GetCustomer();
    }
