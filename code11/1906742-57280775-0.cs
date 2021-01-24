    using (SqlConnection conn = new SqlConnection(connectionString))
    using (SqlCommand cmd = new SqlCommand("select @bytearray = dbcolumn from table", conn))
    {
       SqlParameter outputByteParam = new SqlParameter("@bytearray", SqlDbType.Binary)
       { 
          Direction = ParameterDirection.Output 
       };
    
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.Add(outputByteParam);
    
       conn.Open();
       cmd.ExecuteNonQuery();
    
       byte[] result = outputByteParam.GetValueOrDefault<byte[]>();  // this line might need attention 
    }
