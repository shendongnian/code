    IQueryable<Customer> customers = dataContext.Customers;
    foreach(string inputSearch in search)
    {
        customers = customers.Where(GetFilterFromString(inputSearch));
    }
    IEnumerable<Customer> results = customers.AsEnumerable();
