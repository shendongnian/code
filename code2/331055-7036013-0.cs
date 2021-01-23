    DataTable table = new DataTable();
    
    table.Columns.Add(new DataColumn("A", typeof(int)));
    table.Columns.Add(new DataColumn("B", typeof(String)));
    table.Columns.Add(new DataColumn("C", typeof(Byte)));
    
    for(int i = 0; i < 12000; i++)
    {
    	DataRow row = table.NewRow();
    	row["A"] = "124324"
    	row["B"] = "something";
    	row["C"] = 15;
    
    	table.Rows.Add(row);
    }
    
    String connString = @"Data Source = C:\Database.sdf";
    SqlCeBulkCopy bulkInsert = new SqlCeBulkCopy(connString);
    bulkInsert.DestinationTableName = "Items";
    bulkInsert.WriteToServer(table);
