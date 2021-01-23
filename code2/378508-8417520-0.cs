    TypedDataSet set = new TypedDataSet();
    TypedDataTable.TypedDataRow row = set.TypedDataTable.NewRow();
    row.ColumnA = "Bad Data";
    set.TypedDataTable.AddTypedDataRow(row);
    // At this point the DataSet has column errors and can be checked for...
    if (set.HasErrors)
    {
        // Build some error string container here
        TypedDataSet.TypedDataRow row = tempSet.TypedDataTable.Single();
        var errors = from column in row.GetColumnsInError()
                     select row.GetColumnError(column);
        foreach (var error in errors)
        {
            // Add to error container here
        }
    }
