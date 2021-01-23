    var itemType = items.GetType().GetElementType();
    items.Select(item =>
        dataTable.Rows.Add( // create and add a new row with the following values
            dataTable.Columns
                .Cast<DataColumn>()
                .Select(col => itemType.GetProperty(col.ColumnName))
                .Select(prop => prop != null ? prop.GetValue(item, null) : null)
                .ToArray()
            )
        ).ToList(); // "execute" this thing
