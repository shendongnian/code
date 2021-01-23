    public class Billing
    {
      ICustomerService _customerService;
      public Billing():this(new CustomerService()) {}
      
      public Billing(ICustomerService customerService)
      {
        _customerService = customerService;
      }
    }
