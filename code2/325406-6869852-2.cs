	void Main()
	{
		string colname = "ZipCode";
		
		var dt = new DataTable();
		dt.Columns.Add(colname, typeof(string));
		dt.Rows.Add(new [] { "12345" } );
		dt.Rows.Add(new [] { "67890" } );
		dt.Rows.Add(new [] { "40291" } );
		
		var dt2 = new DataTable();
		dt2.Columns.Add(colname, typeof(string));
		dt2.Rows.Add(new [] { "12345" } );
		dt2.Rows.Add(new [] { "83791" } );
		dt2.Rows.Add(new [] { "24520" } );
		dt2.Rows.Add(new [] { "48023" } );
		dt2.Rows.Add(new [] { "67890" } );
	
	/// With .NET 3.5 LINQ extensions, it can be done inline.
	//	var results = dt.AsEnumerable()
	//			.Select(r => r.Field<string>(colname))
	//			.Intersect(dt2.AsEnumerable()
	//				.Select(r => r.Field<string>(colname)));
	//	Console.Write(String.Join(", ", results.ToArray()));
	
		var results = dt.MatchingRows(dt2, colname);
		foreach (DataRow r in results)
			Console.WriteLine(r[colname]);
	}
	
	public static class Extensions
	{
		/// With .NET 3.0 and no LINQ, create an extension method using yield.
		public static IEnumerable<DataRow> MatchingRows(this DataTable dt, DataTable dtCompare, string colName)
		{
			foreach (DataRow r in dt.Rows)
			{
				if (dtCompare.Select(String.Format("{0} = {1}", colName, r[(colName)])).Length > 0)
					yield return r;
			}
		}
	}
