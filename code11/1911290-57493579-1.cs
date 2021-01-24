    DataRow dataRow = dataTable.NewRow();
    int i = 0;
    foreach (string cell in row.Split(','))
    {
    	if (!columnsAdded)
    	{
    		DataColumn dataColumn = new DataColumn(cell);
    		dataTable.Columns.Add(dataColumn);
    	}
    	else
    	{
    		dataRow[i] = cell;
    	}
        i++;
    }
    if(columnsAdded)
    {
    	dataTable.Rows.Add(dataRow);
    }
    columnsAdded = true;
