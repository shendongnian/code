    using (SqlConnection cn = new SqlConnection(connectionString))
    {
      using (SqlCommand cm = new SqlCommand(commandString, cn))
      {
         using (SqlDataReader dr = cm.ExecuteReader();
         {
            // use dr to read values.
         }
      }
    }        
