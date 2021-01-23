	string colname = "ZipCode";
	
	var dt = new DataTable();
	dt.Columns.Add(colname, typeof(String));
	dt.Rows.Add(new [] { "12345" } );
	dt.Rows.Add(new [] { "67890" } );
	dt.Rows.Add(new [] { "40291" } );
	dt.Dump();
	
	var dt2 = new DataTable();
	dt2.Columns.Add(colname, typeof(String));
	dt2.Rows.Add(new [] { "12345" } );
	dt2.Rows.Add(new [] { "83791" } );
	dt2.Rows.Add(new [] { "24520" } );
	dt2.Rows.Add(new [] { "48023" } );
	dt2.Rows.Add(new [] { "67890" } );
	
	var results = dt.AsEnumerable()
            .Select(r => r.Field<string>(colname))
            .Intersect(dt2.AsEnumerable()
                .Select(r => r.Field<string>(colname)));
	Console.Write(String.Join(", ", results.ToArray()));
