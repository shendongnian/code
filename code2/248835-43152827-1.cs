    Csv csv = new Csv("\t");//Needed delimiter 
    var columnNames = dt.Columns.Cast<DataColumn>().
        Select(column => column.ColumnName).ToArray();
    
    csv.AddRow(columnNames);
    
    foreach (DataRow row in dt.Rows)
    {
        var fields = row.ItemArray.Select(field => field.ToString()).ToArray;
        csv.AddRow(fields);   
    }
    
    csv.Save();
