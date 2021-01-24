    var oldCustomerServices = _context.CustomerServices.Find(CustomerServices.Id); // <-- I have assumed primary key name of `CustomerServices` is `Id`. If anything else then use that.
    if(oldCustomerServices == null)
    {
        CustomerServices newCustomerServices = new CustomerServices()
        {
          // Populate the customer service property here
        }
        _context.CustomerServices.Add(newCustomerServices);
    } 
    else
    {
         _context.Entry(oldCustomerServices).State = EntityState.Modified;
    }
     
    var oldCustomer = _context.Customers.Find(objSv.CustomerServices.strUserID);
    
    if (oldCustomer == null) 
    {
       Customer newCustomer = new Customer()
       {
           // Populate the customer property here
       }
       _context.Customers.Add(newCustomer);
      _context.CustomerServices.Add(objSv.CustomerServices);
    }
    else
    {
      _context.Entry(oldCustomer).State = EntityState.Modified;
    }
    
    _context.SaveChanges();
