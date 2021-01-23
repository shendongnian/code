    string sCSVConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PATHTOFILE + @";Extended Properties='text;HDR=Yes;FMT=Delimited(,)';";
    
    using ( OleDbConnection connection = new OleDbConnection(sCSVConnectionString))
    {
    	connection.ConnectionString = sCSVConnectionString;
    	connection.Open();
    	
    	using (DbCommand command = connection.CreateCommand())
    	{
    		command.CommandText = "SELECT * FROM [" + FILENAME + "]";
    
    		using (DbDataReader dr = command.ExecuteReader())
    		{
    			while (dr.Read())
    			{
    				// do something with the DataReader dr here.
    			}
    
    			dr.Close();
    		}
    	}
    	
    	connection.Close();
    }
