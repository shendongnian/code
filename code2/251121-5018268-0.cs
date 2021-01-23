    using (var connection = new SqlConnection(connectionString))
    {
      connection.Open();
      using (var transaction = new SqlTransaction(IsolationLevel.Serializable))
      {
        ...
        transaction.Commit();
      }
    }
