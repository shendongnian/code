	public DataRow GetHeadersNew(DataTable dt)
    {
    	DataRow row = dt.NewRow();    	
		DataColumnCollection columns = dt.Columns;
        for (int i = 0 ;i <columns.Count ;i++)
        {
             row[i] = columns[i].ColumnName;
        }		
    	return row;
    }
