    if (ds.Tables.Count > 0)
    {
    	var table = ds.Tables[0];
    	var columnName = "QuesType";
    	if (table.Rows.Count > 0 && table.Columns.Contains(columnName))
    	{
    		var tableRow = table.Rows[0];
    		var quesType = tableRow.Field<QuesType>(columnName);
    		if (quesType != null && quesType.ItemArray.Count() > 0)
    		{
    			tab.Text = quesType.ItemArray[0];
    		}
    	}
    }
