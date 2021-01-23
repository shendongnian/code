    public static List<string> GetColumns(string connectionString, string queryString)
    {
    	using (SqlConnection connection = new SqlConnection(connectionString))
    	{
    		SqlDataAdapter adapter = new SqlDataAdapter();
    		adapter.SelectCommand = new SqlCommand(queryString, connection);
    
    		connection.Open();
    		List<string> columnNames = new List<string>();
    		SqlDataReader reader = adapter.SelectCommand.ExecuteReader();
    		for (int xx = 0; xx < reader.FieldCount; xx++)
    		{
    			columnNames.Add(reader.GetName(xx));
    		}
    		return columnNames;
    	}
    }
