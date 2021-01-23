    using (SqlConnection conn = new SqlConnection())    
    {
        SqlCommand cmd = new SqlCommand("sp", conn);   cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@param", SqlDbType.Int, int.MaxValue, ParameterDirection.Output));
 
        conn.Open();
        cmd.ExecuteNonQuery();
        int id = cmd.Parameters["@param"].Value;
 
        conn.Close();    
     }
