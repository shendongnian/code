    public static string tableToCsv(DataTable DT)
    {
    	System.Text.StringBuilder csv = new System.Text.StringBuilder();
    	System.Text.StringBuilder rowData = new System.Text.StringBuilder();
    	DataRow DR = null;
    	DataColumn DC = null;
    
    	foreach (DataColumn DC_loopVariable in DT.Columns) {
    		DC = DC_loopVariable;
    		rowData.Length = 0;
    		rowData.Append((rowData.Length > 0 ? ";" : "").ToString());
    		rowData.Append(DC.ColumnName);
    	}
    	csv.Append(rowData.ToString()).Append(Strings.Chr(13));
    
    	foreach (DataRow DR_loopVariable in DT.Rows) {
    		DR = DR_loopVariable;
    		rowData.Length = 0;
    		foreach (DataColumn DC_loopVariable in DT.Columns) {
    			DC = DC_loopVariable;
    			rowData.Append((rowData.Length > 0 ? ";" : "").ToString());
    			rowData.Append(DR[DC.ColumnName].ToString());
    		}
    		csv.Append(rowData.ToString()).Append(Strings.Chr(13));
    	}
    	return csv.ToString();
    }
