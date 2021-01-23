    private void loadResults(ref DataTable table)
	{
		//Remove previous model
		foreach (var col in dtResult.Columns)
		{
			dtResult.RemoveColumn(col);
		}
		//Set the number of columns to type string 
		//(could use Row.DataType, but would require some work when adding values)
		List<System.Type> colTypes = new List<System.Type>();
		for (int col_it = 0; col_it < table.Columns.Count; col_it++)
		{
			colTypes.Add(typeof(string));
		}
		ListStore resultListStore = new ListStore(colTypes.ToArray());
		//Adding columns
		for (int col_it = 0; col_it < table.Columns.Count; col_it++)
		{
			dtResult.AppendColumn(table.Columns[col_it].ColumnName, new CellRendererText(), "text", col_it);
		}
		//Adding values
		List<string> rowValues = new List<string>();
		for (int row_it = 0; row_it < table.Rows.Count; row_it++)
		{
			for (int col_it = 0; col_it < table.Columns.Count; col_it++)
			{
				rowValues.Add(table.Rows[row_it][col_it].ToString());
			}
			resultListStore.AppendValues(rowValues.ToArray());
			rowValues.Clear();
		}
		//updating model
		dtResult.Model = resultListStore;
	}
