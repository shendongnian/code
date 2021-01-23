    using (SqlCeConnection connection = new SqlCeConnection(@"Data Source=MyDatabase1.sdf"))
    {
      connection.Open();
      if (connection.TableExists("MyTable"))
      {
         // The table exists
      }
      else
      {
        // The table does not exist
      }
    }
