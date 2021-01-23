    DataSet ds = null;
    List<SqlParameter> spParams = ...
    
    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
        using (SqlCommand command = new SqlCommand(spName, connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.AddRange(spParams);
            connection.Open();
    
            IDbDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
    
            ds = new DataSet("rawData");
            da.Fill(ds);
    
            ds.Tables[0].TableName = "row";
            foreach (DataColumn c in ds.Tables[0].Columns)
            {
                 c.ColumnMapping = MappingType.Attribute;
            }
        }
    }
    
    // here is you have DataSet flled in by data so could delegate processing up to the particular DAL client
