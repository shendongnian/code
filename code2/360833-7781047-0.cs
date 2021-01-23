    foreach (var definition in columnDefinitions)  // Some list of what the column types are
    {
        var columnSpec = new DataColumn
            {
                DataType = definition.Type, // This is of type System.Type
                ColumnName = defintion.Name // This is of type string
            };
        this.dataGrid.Columns.Add(columnSpec);
    }
