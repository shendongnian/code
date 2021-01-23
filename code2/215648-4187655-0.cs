    string[] tempfin = table.Split(',');
    string username = null;
    try
    {
    	connection.Open();
    	SQLParameter parUserName = new SqlParameter("@username", System.Data.SqlDbType.VarChar,100);
    	if(username != null) parUserName.Value = username; else parUserName.Value = DBNull.Value;
    	
    	SQLParameter parHope = new SqlParameter("@hope", System.Data.SqlDbType.VarChar,256);
    	
    	command.Parameters.Add(parUserName);
    	command.Parameters.Add(parHope);
    	foreach (string hope in tempfin)
    	{
    		parHope.Value = hope;
    		command.CommandText = "INSERT INTO ATable (Tried, Username) VALUES (@hope,@username)";
    		command.ExecuteNonQuery();
    	}
    }
    finally{
    	if (connection.State != System.Data.ConnectionState.Closed)
    		connection.Close();
    	if(command != null)
    		command.Dispose();	
    }
