    [DataContract]
    public class AuditSheet
    {
       [DataMember]
       public CustomerInfo CustomerInfo{get; set;}
    }
    
    [DataContract]
    public class CustomerInfo
    {
       [DataMember]
       public string CustomerName {get;set;}
    
       //rest of the members go here...
    }
