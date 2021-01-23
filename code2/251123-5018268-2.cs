    using (SqlConnection connection = new SqlConnection(connectionString))
    {
      connection.Open();
      SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable);
      try
      {
        ...
        transaction.Commit();
      }
      catch (Exception)
      {
        transaction.Rollback();
        ...
      }
    }
