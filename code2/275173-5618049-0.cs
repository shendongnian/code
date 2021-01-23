    using (SqlConnection con = new SqlConnection(connectionString))
    {
      using (SqlCommand cmd = new SqlCommand())
      {
        cmd.Connection = con;
        cmd.CommandText 
          = "SELECT * FROM Custromer c JOIN Customer_x_Billing cb ON c.'customer id' = cd.'customer id' Where last_change < @lastChangeDate";
        cmd.Parameters.AddWithValue("@lastChangeDate",  new DateTime(2011,04,03));
        using (SqlDataReader drd = cmd.ExecuteReader())
        {
          while (drd.Read())
          {
            // Read from data reader
          }
        }
      }
    }
