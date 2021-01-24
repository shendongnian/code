    var list = new List<KeyValuePair<int, string>>()
    
    using(var connection = new SqlConnection(connectionString)) 
    using(var command = new SqlCommand("SELECT * FROM interview_Table", connection))
    using(var reader = command.ExecuteReader())
    {
    	if (connection.State != ConnectionState.Open) { connection.Open(); }
    			
    	if (reader.HasRows)
    	{
    		foreach (var row in reader)
    		{
    			//ensurance
    			var isValidId = int.TryParse(row["Id"]?.ToString(), int out id);
    			
    			var description = row["Description"]?.ToString();		
    			
    			// only fetch rows with a valid id number with description that is not empty or null
    			if(isValidId && !string.IsNullOrEmpty(description))
    			{
    				list.Add(new KeyValuePair<int, string>(id, description));
    			}					
    		}
    	}
    }
