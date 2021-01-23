    public static List<string> GetTables(string connectionString)
    {
    	using (SqlConnection connection = new SqlConnection(connectionString))
    	{
    		connection.Open();
    		DataTable schema = connection.GetSchema("Tables");
    		List<string> TableNames = new List<string>();
    		foreach (DataRow row in schema.Rows)
    		{
    			TableNames.Add(row.Field<string>("table_name"));
    		}
    		return TableNames;
    	}
    }
