    private static DataTable RegenerateDataTableInCommon(DataTable dt, DataTable dt2)
    {
    	var dtRows = dt.Rows.Cast<DataRow>();
    	var dtColumnNames = dt.Columns.Cast<DataColumn>().Select(dtC => dtC.ColumnName);
    
    	var dt2Rows = dt2.Rows.Cast<DataRow>();
    	var colNameCandidates = dt2.Columns.Cast<DataColumn>().Select(dtC => dtC.ColumnName).Where(colName => dtColumnNames.Contains(colName));
    
    	List<string> outColumns = new List<string>();
    	foreach (var name in colNameCandidates)
    	{
    		if (dtRows.First()[name] == dt2Rows.First()[name])
    		{
    			outColumns.Add(name);
    		}
    	}
    
    	DataTable outDt = new DataTable();
    	outDt.Clear();
    	DataRow nRow = outDt.NewRow();
    	foreach (var colName in outColumns)
    	{
    		outDt.Columns.Add(colName);
    		nRow[colName] = dtRows.First()[colName];
    	}
    	outDt.Rows.Add(nRow);
    
    	return outDt;
    }
