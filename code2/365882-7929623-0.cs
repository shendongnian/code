    // SqlConnection implements IDisposable, will be disposed after bracket is closed
    using(SqlConnection conn = new SqlConnection())
    {
          conn.Open();
          // SqlCommand implements IDisposable, will be disposed after bracket is closed
          using(SqlCommand command = conn.CreateCommand())
          {
             // DataReader implements IDisposable, will be disposed after bracket is closed
             using(var reader = command.ExecuteReader())
             {
                while (reader.Read())
                { 
                  // read here.
                }
             }
          }
    }
