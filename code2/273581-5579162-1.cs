    // let's create the table and its columns
    var dataTable = new DataTable("My Table");
    dataTable.Columns
             .AddRange(new[] { "Name", "Address" }
                           .Select(n => new DataColumn(n))
                           .ToArray());
    // the items to be added
    var items = new[]
    {
        new { Name = "Bob", Address = "Foo Street" },
        new { Name = "Joe", Address = "Bar Road" },
        new { Name = "Jon", Address = "Baz Avenue" },
    };
    var itemType = items.GetType().GetElementType();
    var rowDatas =
        items.Select(item =>
            from col in dataTable.Columns.Cast<DataColumn>()
            let prop = itemType.GetProperty(col.ColumnName)
            select new
            {
                col.ColumnName,
                Value = prop != null
                    ? prop.GetValue(item, null)
                    : null,
            });
    foreach (var rowData in rowDatas)
    {
        var row = dataTable.NewRow();
        foreach (var cell in rowData)
            row[cell.ColumnName] = cell.Value;
    }
