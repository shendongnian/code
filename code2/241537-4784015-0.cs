    SqlCommand sqlcmd = null;
    
    SqlParameter pField1 = new SqlParameter("@Field1", System.Data.SqlDbType.VarChar, 255);
    ...
    SqlParameter pField20 = new SqlParameter("@Field20", System.Data.SqlDbType.VarChar, 255);
    
    sqlcmd.Parameters.Add(pField1);
    ...
    sqlcmd.Parameters.Add(pField20);
    
    try{
    	sqlcmd = new SqlCommand("INSERT INTO myTable (field1...field20) VALUES (@Field1,...,@Field20",sqlConn)
    	
    	for(int i =0; i < arr.length; i++)
    	{
    		pField1.value = arr[i].field1;
    		...
    		pField20.value = arr[i].field20;
    		sqlCmd.ExecuteNonQuery();
    	}
    }
    catch (Exception ex)
    {
    	LogError(ex.message)
    }
    finally
    {
    	if (sqlconn != null && sqlconn.State != System.Data.ConnectionState.Closed)
    		sqlconn.Close();
    	if (sqlcmd != null)
    		sqlcmd.Dispose();
    }
