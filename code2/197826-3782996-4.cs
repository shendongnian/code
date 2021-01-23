    IQueryable<Customer> SearchCustomers (params string[] keywords)
    {
      var predicate = PredicateBuilder.False<Customer>();
    
      foreach (string keyword in keywords)
      {
        // Note that you *must* declare a variable inside the loop
        // otherwise all your lambdas end up referencing whatever
        // the value of "keyword" is when they're finally executed.
        string temp = keyword;
        predicate = predicate.Or (p => p.Forenames.Contains (temp));
      }
      return dataContext.Customers.Where (predicate);
    }
