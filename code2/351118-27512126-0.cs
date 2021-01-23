    DataTable dataTable1; // Load with data
    DataTable dataTable2; // Load with data (same schema)
    
        var differences =
            dataTable1.AsEnumerable().Except(dataTable2.AsEnumerable(),
                                                DataRowComparer.Default);
        
        return differences.Any() ? differences.CopyToDataTable() : new DataTable();
