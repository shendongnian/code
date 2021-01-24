    SHRSContext shrsContext = new SHRSContext();
    
    DbCommand cmd = shrsContext.Database.Connection.CreateCommand();
    
    cmd.CommandText = "PKG_SHRS.VALIDATELOGIN";
    cmd.CommandType = CommandType.StoredProcedure;
    
    var pinUsername = new OracleParameter("pinUsername", OracleDbType.Varchar2, ParameterDirection.Input);
    pinUsername.Value = "admin";
    
    // Assuming output parameter in the procedure is poutUserCursor
    var poutUserCursor = new OracleParameter("poutUserCursor", OracleDbType.RefCursor, ParameterDirection.Output);
    
    cmd.Parameters.Add(pinUsername);
    cmd.Parameters.Add(poutUserCursor);
    
    cmd.Connection.Open();
    
    DbDataReader dr = cmd.ExecuteReader();
    
    string column1 = string.Empty;
    string column2 = string.Empty;
    
    if (dr.Read())
    {
    	// GetString will return string type. You can change as you need
    	column1 = dr.GetString(0);
    	column2 = dr.GetString(1);
    }
    
    cmd.Connection.Close();
