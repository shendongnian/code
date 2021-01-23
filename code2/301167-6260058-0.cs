    private static string GetTextFromDataTable(DataTable dataTable)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(string.Join(",", dataTable.Columns.Cast<DataColumn>().Select(arg => arg.ColumnName)));
        foreach (DataRow dataRow in dataTable.Rows)
            stringBuilder.AppendLine(string.Join(",", dataRow.ItemArray.Select(arg => arg.ToString())));
        return stringBuilder.ToString();
    }
