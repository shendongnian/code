    string strquery = "BEGIN; SELECT PROC_INSERT_TEST_WITH_RETURN(123,'Test3','Test3','T','T',";
    strquery = strquery + "'" + DateTime.Now.ToString("MMM-dd-yyyy HH:mm:ss") + "',1,9,1234,";
    strquery = strquery + "'" + DateTime.Now.ToString("MMM-dd-yyyy HH:mm:ss") + "')";
    
    NpgsqlCommand cmd = new NpgsqlCommand(strquery, _connection);
    _connection.Open();
    object cursorVal = cmd.ExecuteScalar();
    DataSet ds = FetchAll(_connection, cursorVal);
    cmd.Dispose();
    _connection.Close();
    
    
    private DataSet FetchAll(NpgsqlConnection _connection, object cursorVal)
    {
    	try
    	{
    		DataSet actualData = new DataSet();
    
    		string strSql = "fetch all from \"" + cursorVal + "\";";
    		NpgsqlCommand cmd = new NpgsqlCommand(strSql, _connection);
    		NpgsqlDataAdapter ada = new NpgsqlDataAdapter(cmd);
    		ada.Fill(actualData);
    
    		return actualData;
    
    	}
    	catch (Exception Exp)
    	{
    		throw new Exception(Exp.Message);
    	}
    }
