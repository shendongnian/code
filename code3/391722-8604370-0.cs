    Customer[] customers = ...;
    List<ExtendedCustomer> extendedCustomers = ...;
    extendedCustomers.AddRange(
           customers.Select(c => new ExtendedCustomer{ Customer = c }));
    
