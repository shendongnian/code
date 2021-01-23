    DataTable dataTable1; // Load with data
    DataTable dataTable2; // Load with data (same schema)
    // Fast check for row count equality.
    if ( dataTable1.Rows.Count != dataTable2.Rows.Count) {
        return true;
    }
    var differences =
        dataTable1.AsEnumerable().Except(dataTable2.AsEnumerable(),
                                                DataRowComparer.Default);
        
    return differences.Any() ? differences.CopyToDataTable() : new DataTable();
