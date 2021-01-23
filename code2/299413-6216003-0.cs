    public IEnumerable<Customer> FindCustomers(string partialCustomerName)
    {
        if (string.IsNullOrEmpty(partialCustomerName)) 
          throw new ArgumentException("partialCustomerName must be at least one character long");
    
        var criteria = Criteria.Create<Customer, string>(cust =>   cust.CustomerName, Criteria.ComparisonOp.Like, partialCustomerName + "%");
        int totalRecords;
        var col = new BusinessObjectCollection<Customer>();
        col.LoadWithLimit(criteria, 0, 20, ref totalRecords);
        return col;
    }
