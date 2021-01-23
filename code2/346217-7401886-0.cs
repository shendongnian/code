        // Load the data into the existing DataSet. 
        DataTableReader reader = GetReader();
        dataSet.Load(reader, LoadOption.OverwriteChanges,
        customerTable, productTable); 
        // Load the data into the DataTable.
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        DataTable dt = new DataTable();
        dt.Load(dr);
