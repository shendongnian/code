    public static DataTable RemoveDuplicateRows(this DataTable dataTable)
    {
    	List<string> columnNames = new List<string>();
    	foreach (DataColumn col in dataTable.Columns)
    	{
    		columnNames.Add(col.ColumnName);
    	}
    	return dataTable.DefaultView.ToTable(true, columnNames.Select(c => c.ToString()).ToArray());
    }
