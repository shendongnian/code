	var dt4 = new DataTable();
	//add all the columns
	foreach (DataColumn c in 
		dt.Columns.Cast<DataColumn>()
			.Union(dt2.Columns.Cast<DataColumn>())
			.Union(dt3.Columns.Cast<DataColumn>()))
	{
		dt4.Columns.Add(c.ColumnName, c.DataType);
	}
	if(dt.Rows.Count != dt2.Rows.Count|| dt.Rows.Count != dt3.Rows.Count)
		throw new Exception("DataTables had different row counts");
	for (int i = 0; i < dt.Rows.Count; i++)
	{
		var row = dt4.Rows.Add();
		foreach (DataColumn c in dt.Columns)
			if (dt.Rows[i][c] != DBNull.Value)
				row[c.ColumnName] = dt.Rows[i][c];
		foreach (DataColumn c in dt2.Columns)
			if (dt2.Rows[i][c] != DBNull.Value)
				row[c.ColumnName] = dt2.Rows[i][c];
		foreach (DataColumn c in dt3.Columns)
			if (dt3.Rows[i][c] != DBNull.Value)
				row[c.ColumnName] = dt3.Rows[i][c];
	}
