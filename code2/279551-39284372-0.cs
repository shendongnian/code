    // Create a table of five different people.
    	// ... Store their size and sex.
    	DataTable table = new DataTable("Players");
    	table.Columns.Add(new DataColumn("Size", typeof(int)));
    	table.Columns.Add(new DataColumn("Sex", typeof(char)));
    
    	table.Rows.Add(100, 'f');
    	table.Rows.Add(235, 'f');
    	table.Rows.Add(250, 'm');
    	table.Rows.Add(310, 'm');
    	table.Rows.Add(150, 'm');
    
    	// Search for people above a certain size.
    	// ... Require certain sex.
    	DataRow[] result = table.Select("Size >= 230 AND Sex = 'm'");
    	foreach (DataRow row in result)
    	{
    	    Console.WriteLine("{0}, {1}", row[0], row[1]);
    	}
