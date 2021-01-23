    DataRow firstRow = table.NewRow();
    List<string> names = new List<string>();
    foreach (DataColumn column in table.Columns)
    {
        names.Add(column.ColumnName);
    }
    firstRow.ItemArray = names.ToArray();
    table.Rows.InsertAt(firstRow, 0);
