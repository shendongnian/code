    IQueryable<Customer> SearchCustomers (params string[] keywords)
    {
      var predicate = PredicateBuilder.False<Customer>();
    
      foreach (string keyword in keywords)
      {
        string temp = keyword;
        predicate = predicate.Or (p => p.Forenames.Contains (temp));
      }
      return dataContext.Customers.Where (predicate);
    }
