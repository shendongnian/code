    var customers = context.Customers.AsQueryable();
    for (string name in nameSearch) {
        string curName = name;
        customers = customers.Where(r => r.CustName.Contains(curName));
    }
    Data.Customer[] results = customers.ToArray();
