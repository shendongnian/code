    public DataTable Copy()
    {
    	IntPtr intPtr;
    	Bid.ScopeEnter(out intPtr, "<ds.DataTable.Copy|API> %d#\n", this.ObjectID);
    	DataTable result;
    	try
    	{
    		DataTable dataTable = this.Clone();
    		foreach (DataRow row in this.Rows)
    		{
    			this.CopyRow(dataTable, row);
    		}
    		result = dataTable;
    	}
    	finally
    	{
    		Bid.ScopeLeave(ref intPtr);
    	}
    	return result;
    }
    
    internal void CopyRow(DataTable table, DataRow row)
    {
    	int num = -1;
    	int newRecord = -1;
    	if (row == null)
    	{
    		return;
    	}
    	if (row.oldRecord != -1)
    	{
    		num = table.recordManager.ImportRecord(row.Table, row.oldRecord);
    	}
    	if (row.newRecord != -1)
    	{
    		if (row.newRecord != row.oldRecord)
    		{
    			newRecord = table.recordManager.ImportRecord(row.Table, row.newRecord);
    		}
    		else
    		{
    			newRecord = num;
    		}
    	}
    	DataRow dataRow = table.AddRecords(num, newRecord);
    	if (row.HasErrors)
    	{
    		dataRow.RowError = row.RowError;
    		DataColumn[] columnsInError = row.GetColumnsInError();
    		for (int i = 0; i < columnsInError.Length; i++)
    		{
    			DataColumn column = dataRow.Table.Columns[columnsInError[i].ColumnName];
    			dataRow.SetColumnError(column, row.GetColumnError(columnsInError[i]));
    		}
    	}
    }
