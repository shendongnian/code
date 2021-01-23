    using (SqlConnection conn = new SqlConnection(connString))
    using (SqlCommand comm = new SqlCommand(selectStatement, conn))
    {
       try
       {
          conn.Open();
          using (SqlDataReader dr = comm.ExecuteReader())
          {
             if (dr.HasRows)
             {
                while (dr.Read())
                {
                   Console.WriteLine(dr["Person"].ToString());
                }
             }
             else Console.WriteLine("No C-Level with Head Up Ass Found!? (Very Odd)");
          }
       }
       catch (Exception e) { Console.WriteLine("Error: " + e.Message); }
       if (conn.State == System.Data.ConnectionState.Open) conn.Close();
    }
