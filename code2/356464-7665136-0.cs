    var matchingCustomers = _CustomerList;
    if (!string.IsNullOrEmpty(lname))
    {
        matchingCustomers = matchingCustomers.Where(x => x.LastName == lname);
    }
    if (!string.IsNullOrEmpty(fname))
    {
        matchingCustomers = matchingCustomers.Where(x => x.FirstName == fname);
    }
    //...
    return matchingCustomers.ToList();
