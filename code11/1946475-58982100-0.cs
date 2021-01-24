    public class Customer
    {
      public Customer()
      {
        CustomerId = Utilities.RandomString(6);
      }
      public string CustomerId { get; }
      public string CustomerName { get; set; }
    }
