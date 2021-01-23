    var isRolledBack = false;
    using (var connection = new SqlConnection())
    {
      using (var transaction = connection.BeginTransaction())
      {
        try
        {
          // do your stuff here with transaction
        }
        catch (Exception ex)
        {
          transaction.Rollback();
          isRolledBack = true;
          throw;
        }
      }
    }
