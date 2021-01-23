    StringBuilder sb = new StringBuilder(); 
			
    var columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
    sb.AppendLine(string.Join(",", columnNames));
    foreach (DataRow row in dt.Rows)
    {
        var fields = row.ItemArray.Select(field => field.ToString());
        sb.AppendLine(string.Join(",", fields));
    }
    File.WriteAllText("test.csv", sb.ToString());
