    IQueryable<Customer> SearchCustomers (string[] forenameKeyWords, string[] surnameKeywords)
    {
        var predicate = PredicateBuilder.True<Customer>();
        
        var forenamePredicate = PredicateBuilder.False<Customer>();
        foreach (string keyword in forenameKeyWords)
        {
          string temp = keyword;
          forenamePredicate = forenamePredicate.Or (p => p.Forenames.Contains (temp));
        }
        predicate = PredicateBuilder.And(forenamePredicate);
        
        var surnamePredicate = PredicateBuilder.False<Customer>();
        foreach (string keyword in surnameKeyWords)
        {
          string temp = keyword;
          surnamePredicate = surnamePredicate.Or (p => p.Surnames.Contains (temp));
        }
        predicate = PredicateBuilder.And(surnamePredicate);
        
        return dataContext.Customers.Where(predicate);
    }
