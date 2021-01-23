    void RunStoredProc1(object arg1)
    {
        try
        {
            using(SqlConnection conn = new SqlConnection(connStr))
            {
                using SqlCommand cmd = new SqlCommand("storedProc1", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@input1", arg1);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        } 
        catch (Exception ex)
        {
          //handle the exception appropriately.
        }
    }
