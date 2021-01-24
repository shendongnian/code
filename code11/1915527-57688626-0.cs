    var data = new DataTable();
    data.Columns.Add("Name");
    data.Columns.Add("Id");
    
    for (var i = 1; i< 10_000; i++)
    {
    	data.Rows.Add($"Name={i+1}", i+1); 
    }
    
    using (var sqlBulk = new SqlBulkCopy(_connectionstring))
    {
    	sqlBulk.DestinationTableName = "People";
    	sqlBulk.WriteToServer(data);
    }
