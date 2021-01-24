	private void CheckColumns()
	{
		//table which we want to check
		DataTable table = new DataTable();
		//add column definition - first column will be string, other two are int columns
		table.Columns.Add("string column", typeof(string));
		table.Columns.Add("int column 1", typeof(int));
		table.Columns.Add("int column 2", typeof(int));
		//add data - in this example rows "abc" and "ghi" are valid because they have at least one numeric column
		table.Rows.Add(new object[] { "abc", 1, 2 });
		table.Rows.Add(new object[] { "def", null, null });
		table.Rows.Add(new object[] { "ghi", null, 2 });
		table.Rows.Add(new object[] { "jkl", null, null });
		//filter rows in a way, using Linq, that rows are filtered where at least one column has numeric value
		var validRows = table.AsEnumerable().Where(r => r.ItemArray.Any(c => IsNumeric(c))).ToList();
	}
    //this is helper method that code will call for each value in each row
	private bool IsNumeric(object value)
	{
		int outputValue;
		return int.TryParse(value.ToString(), out outputValue);
	}
