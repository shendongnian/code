    if (DBConn.State == ConnectionState.Open)
    {
       try
       {
          using(SqlCommand cmd = new SqlCommand(DBConn))
          {
             cmd.CommandText = "SELECT 0";
             cmd.ExecuteNonQuery();
          }
       }
       Catch
       {
          DBConn.Close(); \\Declare the connection dead.
       }
    }
