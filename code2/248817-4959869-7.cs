    StringBuilder sb = new StringBuilder(); 
			
    string[] columnNames = dt.Columns.Cast<DataColumn>().
                                      Select(column => column.ColumnName).
                                      ToArray();
    sb.AppendLine(string.Join(",", columnNames));
    foreach (DataRow row in dt.Rows)
    {
        string[] fields = row.ItemArray.Select(field => field.ToString()).
                                        ToArray();
        sb.AppendLine(string.Join(",", fields));
    }
    File.WriteAllText("test.csv", sb.ToString());
