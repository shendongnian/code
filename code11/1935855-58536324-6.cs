    public static IEnumerable<TItem> FromSql<TItem>(
    	this DbContext dbContext,
    	string query)
    	where TItem : class, new()
    {
    	var sqlConnection = (SqlConnection)dbContext.Database.GetDbConnection();	
    	var items = new List<TItem>();
    	using (var sqlCommand = sqlConnection.CreateCommand())
    	{
    		sqlCommand.CommandType = CommandType.Text;
    		sqlCommand.CommandText = query;
    
    		sqlConnection.Open();
    
    		try
    		{
    			using (var reader = sqlCommand.ExecuteReader())
    			{			
    				var parsedItems = Parse(reader, typeof(TItem));
    				if (parsedItems != null)
    				{
    					items = parsedItems.OfType<TItem>().ToList();
    				}
    			}
    		}
    		finally
    		{
    			sqlConnection.Close();
    		}
    	}
    	return items;
    }
