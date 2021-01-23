    public void ConnectToSQl(SqlConnection conn, String word, int count, String HashTag = " ")
    {   
    	if (conn.State != ConnectionState.Open)
    		throw new SqlExecutionException("Sqlconnection is not open");
        checkExcludeList();
    
    	SqlCommand Command = new SqlCommand(
    		"INSERT INTO word_list (word , count)" +
    		"VALUES (@word , @count)", conn);
    
    	//add parameters for insert
    	Command.Parameters.AddWithValue("@word", word);
    	Command.Parameters.AddWithValue("@count", count);
    
    	Command.ExecuteNonQuery();
    
    }
