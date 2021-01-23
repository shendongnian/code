    [QueryInterceptor("Orders")]
    public Expression<Func<Order, bool>> FilterOrders() 
    {
        return o => o.Customer.Name == /* Current principal name. */;
    } 
     
    // Insures that the user accessing the customer(s) has the appropriate
    // rights as defined in the QueryRules object to access the customer
    // resource(s).
     
    [QueryInterceptor ("Customers")]
    public Expression<Func<Customer, bool>> FilterCustomers() 
    {
      return c => c.Name == /* Current principal name. */ &&
                  this.CurrentDataSource.QueryRules.Contains(
                    rule => rule.Name == c.Name &&
                            rule.CustomerAllowedToQuery == true
                  );
    }
