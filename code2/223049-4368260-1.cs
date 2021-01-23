    using (SqlConnection con = new SqlConnection(connectionString))
    {
       try
       {
          con.Open();
       }
       catch (Exception)
       {
          // Cant Connect
       }
    }
