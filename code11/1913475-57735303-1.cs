    DataTable dt = new DataTable("Demo");
    
    dt.Columns.AddRange 
    (
    	new DataColumn[] 
    	  {
    	     new DataColumn ( "Number", typeof ( int ) ),
    	     new DataColumn ( "Type", typeof ( int ) ),
    	     new DataColumn ( "Order", typeof ( string ) ),
    	     new DataColumn ( "Count", typeof ( int ) )	 
    	  }
    );
    
    dt.Rows.Add(new object[] { 1,1,"R", 1 });
    dt.Rows.Add(new object[] { 1,1,"R", 1 });
    dt.Rows.Add(new object[] { 1,1,"R", 1 });
    dt.Rows.Add(new object[] { 1,2,"R", 1 });
    
    
    DataTable dt2 = dt.AsEnumerable()
    	.GroupBy(r => new { Number = r["Number"], Type = r["Type"], Order = r["Order"] })
    	.Select(g =>
    	{
    	    var row = dt.NewRow();
    	
    	    row["Number"] = g.Key.Number;
    	    row["Type"] = g.Key.Type;
    	    row["Order"] = g.Key.Order;
    	    row["Count"] = g.Count();
    	
    	    return row;
    	
    	}).CopyToDataTable();
    
    
    foreach (DataRow row in dt2.Rows)
    {
        for (int i = 0; i < dt2.Columns.Count; i++)
            Console.Write("{0}{1}",
                row[i],                                                    // Print column data
                (i < dt2.Columns.Count - 1)? "  " : Environment.NewLine);  // Print column or row separator
    
    }
