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
    items.Select(item =>
        dataTable.Rows.Add( // create and add a new row with the following values
            dataTable.Columns
                .Cast<DataColumn>()
                .Select(col => itemType.GetProperty(col.ColumnName))
                .Select(prop => prop != null ? prop.GetValue(item, null) : null)
                .ToArray()
            )
        ).ToList(); // execute this thing
