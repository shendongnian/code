    using (SqlConnection conn = new SqlConnection(connString))
    {
      using(SqlCommand cmd = conn.CreateCommand())
      {
         cmd.CommandText = "SELECT ID, Name FROM Customers";
  
          conn.Open();
          using (SqlDataReader dr = cmd.ExecuteReader())
          {
              while (dr.Read())
              {
                  // do your thing
              }
          }
      }
    }
