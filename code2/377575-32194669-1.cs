    public string DataTableToCSV(DataTable dt, bool includeHeader, string rowFilter, string sortFilter, bool useCommaDelimiter = false, bool truncateTimesFromDates = false)
    {
    	dt.DefaultView.RowFilter = rowFilter;
    	dt.DefaultView.Sort = sortFilter;
    	DataView dv = dt.DefaultView;
    	string csv = DataTableToCSV(dv.ToTable, includeHeader, useCommaDelimiter, truncateTimesFromDates);
    	//reset the Filtering
    	dt.DefaultView.RowFilter = string.Empty;
    	return csv;
    }
    
    public string DataTableToCsv(DataTable dt, bool includeHeader, bool useCommaDelimiter = false, bool truncateTimesFromDates = false)
    {
    	StringBuilder sb = new StringBuilder();
    	string delimter = Constants.vbTab;
    	if (useCommaDelimiter)
    		delimter = ",";
    
    	if (includeHeader) {
    		foreach (DataColumn dc in dt.Columns) {
    			sb.AppendFormat("{0}" + Constants.vbTab, dc.ColumnName);
    		}
    
    		//remove the last Tab
    		sb.Remove(sb.ToString.Length - 1, 1);
    		sb.Append(Environment.NewLine);
    	}
    
    	foreach (DataRow dr in dt.Rows) {
    		foreach (DataColumn dc in dt.Columns) {
    			if (Information.IsDate(dr(dc.ColumnName).ToString()) & dr(dc.ColumnName).ToString().Contains(".") == false & truncateTimesFromDates) {
    				sb.AppendFormat("{0}" + delimter, Convert.ToDateTime(dr(dc.ColumnName).ToString()).Date.ToShortDateString());
    			} else {
    				sb.AppendFormat("{0}" + delimter, CheckDBNull(dr(dc.ColumnName).ToString().Replace(",", "")));
    			}
    		}
    		//remove the last Tab
    		sb.Remove(sb.ToString.Length - 1, 1);
    		sb.Append(Environment.NewLine);
    	}
    	return sb.ToString;
    }
    
    public enum enumObjectType
    {
    	StrType = 0,
    	IntType = 1,
    	DblType = 2
    }
    
    public object CheckDBNull(object obj, enumObjectType ObjectType = enumObjectType.StrType)
    {
    	object objReturn = null;
    	objReturn = obj;
    	if (ObjectType == enumObjectType.StrType & Information.IsDBNull(obj)) {
    		objReturn = "";
    	} else if (ObjectType == enumObjectType.IntType & Information.IsDBNull(obj)) {
    		objReturn = 0;
    	} else if (ObjectType == enumObjectType.DblType & Information.IsDBNull(obj)) {
    		objReturn = 0.0;
    	}
    	return objReturn;
    }
