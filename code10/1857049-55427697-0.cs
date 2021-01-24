    string sql = "Select * from table01";
    using (var conn = new NpgsqlConnection(cs))
    {
    	conn.Open();
    	using (var cmd = new NpgsqlCommand(sql, conn))
    	{
    		var reader = cmd.ExecuteReader();
    		int fieldCount = reader.FieldCount;
    		var workTable = new DataTable(DateTime.Now.ToString());
    		workTable.Load(reader);
    
    		for (int i = 0; i < workTable.Columns.Count; i++)
    		{
    			Console.WriteLine($"field: {workTable.Columns[i].ColumnName} is of type {workTable.Columns[i].DataType.ToString()}");
    
    		}
    	   
    	}
    }
