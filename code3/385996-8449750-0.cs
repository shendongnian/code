    public bool FilterByID3(Customer cust)
    {
      return cust.ID == 3;
    }
    
        var myQuery = Customers.Where(FilterByID3).First();
