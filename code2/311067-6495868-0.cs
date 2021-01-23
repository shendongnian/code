    users.Select(u =>
      new MyDomainObject(
         u.Id,
         u.Transactions
            .Where(t => false)
            .Select(t => t.TransactionTime)
            .OrderByDescending(x => x)
            .DefaultIfEmpty(DateTime.MinValue)
            .First()
      )
    ); 
