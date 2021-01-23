    IQueryable<??> SearchProducts (params string[] keywords)
    {
      var predicate = PredicateBuilder.True<??>();
    
      foreach (string keyword in keywords)
      {
        string temp = keyword;
        if(temp != String.Empty || temp != "All")
              predicate = predicate.And(e => e.???.Contains (temp));
      }
      return dataContext.??.Where (predicate);
    }
