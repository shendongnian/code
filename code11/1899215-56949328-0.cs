    using (var connection = new FbConnection("database=localhost:test.fdb;user=sysdba;password=masterkey;Charset=NONE;"))
    {
    	connection.Open();
    	using (var transaction = connection.BeginTransaction())
    	{
    		using (var command = new FbCommand("select * from testTable", connection, transaction))
    		{
    			using (var reader = command.ExecuteReader())
    			{
    				while (reader.Read())
    				{
    					var values = new object[reader.FieldCount];
    					reader.GetValues(values);
    					Console.WriteLine(string.Join("|", values));
    				}
    			}
    		}
    	}
    }
