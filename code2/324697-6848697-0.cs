    DataTable table = new DataTable();
    DataTable existing = listOfTables[0];
    for(int i = 20; i < 30; i ++)
    {
        table.Columns.Add(existing.Column[i].Name;
        table.Columns.Add(existing.Column[i + 20].Name;
    }
    
    foreach(DataTable table in listOfTables)
    {
        foreach(DataRow row in table.Rows)
        {
            DataRow newRow = table.NewRecord();
            foreach(Column column in table.Columns)
            {
               newRow[column.Name] = row[column.Name];
            }
            table.Rows.Add(row);
        }
    }
