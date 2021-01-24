C#
    DataTable dt = new DataTable();
	dt.Columns.Add("Col1", typeof(int));
	dt.Columns.Add("Col2", typeof(DateTime));
	dt.Columns.Add("Col3", typeof(int));
	
	dt.Rows.Add(2, DateTime.Parse("2/15/2019"), 25);
	dt.Rows.Add(2, DateTime.Parse("5/25/2019"), 25);
	dt.Rows.Add(2, DateTime.Parse("3/25/2019"), 26);
	
	dt.AsEnumerable()
	.GroupBy(r => new {col1 = r.Field<int>("Col1"), col2 = r.Field<int>("Col3")} )
	.Select(g =>
		g.Select(s=> s).OrderByDescending(o=>o.Field<DateTime>("Col2")).FirstOrDefault()
	);
