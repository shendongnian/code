    using (TransactionScope scope = new TransactionScope())
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        ...
      }
      scope.Complete();
    }
