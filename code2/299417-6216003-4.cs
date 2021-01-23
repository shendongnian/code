    public IEnumerable<Customer> FindCustomers(string partialCustomerName)
    {
        if (string.IsNullOrEmpty(partialCustomerName)) 
          throw new ArgumentException("partialCustomerName must be at least one character long");
        var col = new BusinessObjectCollection<Customer>();
        col.LoadWithLimit("CustomerName Like " + partialCustomerName + "%", "CustomerName", 20);
        return col;
    }
