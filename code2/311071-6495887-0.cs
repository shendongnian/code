    users.Select(u =>
      new MyDomainObject(
         u.Id,
         u.Transactions
            .Where(t => false) // empty results set
            .Select(t => t.TransactionTime)
            .Any() ?
         u.Transactions
            .Where(t => false) // empty results set
            .Select(t => t.TransactionTime) // TransactionTime is DATETIME NOT NULL
            .OrderByDescending(x => x)
            .FirstOrDefault() : // I want DateTime.MinValue (or SqlDateTime.MinValue)
         DateTime.MinValue
      )
    );
