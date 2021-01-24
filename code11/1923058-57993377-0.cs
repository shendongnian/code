    StringBuilder sb = new StringBuilder();
    
    foreach(var table in DataSet.DataTable)
    {
        YourCode(sb);
    }
    void YourCode(StringBuilder stringBuilder)
    {
        DataTable fileData = ***Some Data***
        if (fileData.Rows.Count == 0) 
            return (true, "No Records");
        IEnumerable<string> columnNames = fileData
            .Columns
            .Cast<DataColumn>()
            .Select(column => column.ColumnName);
        stringBuilder.AppendLine(string.Join("|", columnNames));
        foreach (DataRow row in fileData.Rows)
        {
            IEnumerable<string> fields = row.ItemArray
                .Select(field => RemoveSpecialCharacters(field?.ToString().Replace(",",";"))); 
            stringBuilder.AppendLine(string.Join("|", fields));
        }
    }
