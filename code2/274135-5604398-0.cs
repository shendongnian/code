    DataTable t = new DataTable();
    var fwdRowGroups = t.AsEnumerable().GroupBy(row => row.Field<object>("AcctId"));
    
    DataTable g = new DataTable();
    foreach (var row in fwdRowGroups)
    {
    	g.Rows.Add(row);
    }
