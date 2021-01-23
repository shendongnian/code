      try
        {
         using (var con = new SqlConnection(SqlHelper.ConnectionString))
          {
            con.Open();
            using (var com = new SqlCommand("RearrangePuzzles", con))
            {
              com.CommandType = CommandType.StoredProcedure;
              com.Parameters.Add(new SqlParameter("ChangedPuzzles", table) 
                { SqlDbType = SqlDbType.Structured });
              com.ExecuteNonQuery();
            }
            con.Close();
          }
        }
    
    catch (Exception ex)
                    {
                       // ex will show you the error
                    }
