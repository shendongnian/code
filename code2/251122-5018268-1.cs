    using (var scope = new TransactionScope())
    {
      using (var connection = new SqlConnection(connectionString))
      {
        ...
      }
      scope.Complete();
    }
