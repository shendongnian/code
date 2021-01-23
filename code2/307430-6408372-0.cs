    public static class CustomerHelper
    {
       public static Customer Get(int customerId)
       {
          // do access control security
          ...
          // use EF4 to get the customer object
       }
    
       public static void Update(Customer customer)
       {
          // do access control security
          ...
          // use EF4 to update the customer object
       }
    
    }
