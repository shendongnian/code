    public static int CountCars()
    {
        SqlConnection conn = new SqlConnection(connectionString);
        try
        {
          SqlCommand cmd = conn.CreateCommand();
          conn.Open();
          try
          {
            cmd.CommandText = "SELECT COUNT(1) FROM Carsd";
     
            return (int)cmd.ExecuteScalar();
          }
          finally
          {
            if(cmd != null)
              cmd.Dispose();
          }
        }
        finally
        {
          if(cmd != null)
            conn.Dispose();
        }
    }
