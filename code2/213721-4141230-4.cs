    public interface ICustomerInfo {}
    
    [DataContract(Name = "Customer")]
    public class CustomerTypeA : ICustomerInfo {}
    
    [DataContract(Name = "Customer")]
    public class CustomerTypeB : ICustomerInfo {}
    
    [DataContract]
    [KnownType(typeof(CustomerTypeB))] //<-- check it! This applies to 'buyer'
    public class PurchaseOrder
    {
        [DataMember]
        ICustomerInfo buyer;
    
        [DataMember]
        int amount;
    }
