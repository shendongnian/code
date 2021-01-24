    private List<string> GetColumnValues(string columnName, DataTable dataTable)
    {
    	var colValues = new List<string>();
    	foreach (DataRow row in datatable.Rows)
    	{
    		var value = row[columnName];
    		if (value != null)
    		{
    			colValues.Add((string)value);
    		}
    	}
    	return colValues;
    }
