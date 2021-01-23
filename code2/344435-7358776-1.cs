    private ICustomerService _customerService;
    public Billing(ICustomerService customerService)
    {
       _customerService = customerService;
    }
    
    public ActionResult NewCustomer()
    {
      Customer customer = new Customer(){ Name = "test" };
      this._customerService.AddCustomer(customer);
    
      return View();
    }
