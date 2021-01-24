    private static DataTable RegenerateDataTableInCommon(DataTable dt, DataTable dt2)
    {
    	var dtRows = dt.Rows.Cast<DataRow>();
    	var dt2Rows = dt2.Rows.Cast<DataRow>();
    	var dtColumnNames = dt.Columns.Cast<DataColumn>().Select(dtC => dtC.ColumnName);
    
    	var columnNameMatched = dt2.Columns.Cast<DataColumn>().Select(dtC => dtC.ColumnName).Where(colName => dtColumnNames.Contains(colName));
    	var cellValueMatched = columnNameMatched.Where(colName => dtRows.First()[colName] == dt2Rows.First()[colName]);
    
    	DataTable outDt = new DataTable();
    	outDt.Clear();
    	DataRow nRow = outDt.NewRow();
    	foreach (var colName in cellValueMatched)
    	{
    		outDt.Columns.Add(colName);
    		nRow[colName] = dtRows.First()[colName];
    	}
    	outDt.Rows.Add(nRow);
    
    	return outDt;
    }
