    var customerBasicList = context.Customers
                                   .Where(...)
                                   .Select( c => new CustomerBasic() 
                                   {
                                     FirstName = c.FirstName,
                                     LastName = c.LastName,
                                   }).ToList();
