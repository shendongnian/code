    foreach (var commandDefinition in batches)
    {
    	using(var reader = await con.ExecuteReaderAsync(commandDefinition)) {
    		while(!reader.IsClosed) {
    			var table = new DataTable();
    			table.Load(reader);
    			resultSet.Add(table);
    		}
    	}
    }
