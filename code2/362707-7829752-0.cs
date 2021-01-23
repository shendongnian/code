    table.DefaultView.Sort = "code asc";
    foreach (DataRowView row in table.DefaultView)
    {
        Console.WriteLine();
        foreach (DataColumn column in table.Columns)
        {
            Console.WriteLine("{0}: {1}", column.ColumnName, row[column.ColumnName]);
        }
    }
