    public class Customer
    {
      public int CustomerId { get; set;}
     //navigation
      public List<CustomerProperty> CustomerProperties { get; set;}
    }
    
    public class CustomerProperty
    {
      public int CustomerPropertyId { get; set;}
      //navigation
      public Customer Customer { get; set; }
    }
