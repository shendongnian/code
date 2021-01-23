	// Create a table 
	DataTable table = new DataTable("users");
	table.Columns.Add(new DataColumn("Id", typeof(int)));
	table.Columns.Add(new DataColumn("Name", typeof(string)));
	table.Rows.Add(1, "abc");
	table.Rows.Add(2, "ddd");
	table.Rows.Add(3, "fff");
	table.Rows.Add(4, "hhh d");
	table.Rows.Add(5, "hkf ds");
	// Search for given id e.g here 1
	DataRow[] result = table.Select("Id == 1"); // this will return one row for above data 
	foreach (DataRow row in result)
	{
	    Console.WriteLine("{0}, {1}", row[0], row[1]);
	}
