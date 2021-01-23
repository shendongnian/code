    public IEnumerable<Customer> FindCustomers(string partialCustomerName)
    {
        if (string.IsNullOrEmpty(partialCustomerName)) 
          throw new ArgumentException("partialCustomerName must be at least one character long");
    
        return Broker.GetBusinessObjectCollection<Customer>("CustomerName Like " + partialCustomerName + "%", "CustomerName", 20);
    }
