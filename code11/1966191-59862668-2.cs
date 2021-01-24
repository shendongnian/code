    DataTable dt = new DataTable();
    
    foreach (var column in allPlayerDetails.SelectMany(p => p.Keys).Select(k => k.Trim()).Distinct())
    {
    	dt.Columns.Add(new DataColumn(column));
    }
    
    foreach (var details in allPlayerDetails)
    {
    	var dr = dt.NewRow();
    	foreach (DataColumn dc in dt.Columns)
    	{
    		dr[dc.ColumnName] = details.ContainsKey(dc.ColumnName) ? details[dc.ColumnName] : null;
    	}
    	dt.Rows.Add(dr);
    }
    
