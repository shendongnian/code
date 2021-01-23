    for(int i = 0; i< ds.Tables[0].Rows.Count; i++)
    {
    	for(int j = 0; j < ds.Tables[0].Columns.Count; j++)
    	{
    		var columnName = ds.Tables[0].Columns[j].ColumnName;
    		if(columnName == "Number")
    		{
    			ds.Tables[0].Rows[i][columnName] = SpecialFormat(columnName, ds.Tables[0].Rows[i]));
    		}
    	}
    }
    
    private string SpecialFormat(string column, DataRow dataRow)
    {
    	string value = dataRow[column].ToString();
    	if (!string.IsNullOrEmpty(value))
    	{
    		if (value == "0")
    			return "";
    		if (value == "1")
    			return "T";
    	}
    	return "";
    }
