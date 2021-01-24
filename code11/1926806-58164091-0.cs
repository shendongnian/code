    var lines = File.ReadAllLines(file);
    if (lines.Count() == 0) 
        return;
    
    var tableName = GetTableName(file);
    var columns = lines[0].Split(',').ToList();
    var table = new DataTable();
    sqlBulk.ColumnMappings.Clear();
    
    foreach (var c in columns)
    {
        table.Columns.Add(c);
        sqlBulk.ColumnMappings.Add(c, c); 
    }
    
    for (int i = 1; i < lines.Count() - 1; i++)
    {
        var line = lines[i];
        // Explicitly mark empty values as null for SQL import to work
        var row = line.Split(',')
            .Select(a => string.IsNullOrEmpty(a) ? null : a).ToArray();
        table.Rows.Add(row);
    }
    
    sqlBulk.DestinationTableName = tableName;
    sqlBulk.WriteToServer(table);
