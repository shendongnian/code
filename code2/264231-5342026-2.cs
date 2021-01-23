    using (var connection = new OleDbConnection())
    {
      connection.Open();
      using (var command = new OleDbCommand("connectionString"))
      {
         //Do my stuff.
      }
    }
