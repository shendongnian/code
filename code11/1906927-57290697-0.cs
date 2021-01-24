    public static class DataSetExtensions
    {
    	public static DataSet ToAllStringFields(this DataSet ds)
    	{
    		// Clone function -> does not copy the data, but just the structure.
    		var newDs = ds.Clone();
    		foreach (DataTable table in newDs.Tables)
    		{
    			// if the column is not string type -> set as string.
    			foreach (DataColumn col in table.Columns)
    			{
    				if (col.DataType != typeof(string))
    					col.DataType = typeof(string);
    			}
    		}
    
    		// imports all rows.
    		foreach (DataTable table in ds.Tables)
    		{
    			var targetTable = newDs.Tables[table.TableName];
    			foreach (DataRow row in table.Rows)
    			{
    				targetTable.ImportRow(row);
    			}
    		}
    
    		return newDs;
    	}
    }
