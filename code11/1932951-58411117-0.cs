    // Bind the System.Windows.Forms.DataGridView object
    // to the System.Windows.Forms.BindingSource object.
    dataGridView.DataSource = bindingSource;
    
    // Fill the DataSet.
    DataSet ds = new DataSet();
    ds.Locale = CultureInfo.InvariantCulture;
    FillDataSet(ds);
    
    DataTable orders = ds.Tables["SalesOrderHeader"];
    
    // Query the SalesOrderHeader table for orders placed 
    // after August 8, 2001.
    IEnumerable<DataRow> query =
        from order in orders.AsEnumerable()
        where order.Field<DateTime>("OrderDate") > new DateTime(2001, 8, 1)
        select order;
    
    // Create a table from the query.
    DataTable boundTable = query.CopyToDataTable<DataRow>();
    
    // Bind the table to a System.Windows.Forms.BindingSource object, 
    // which acts as a proxy for a System.Windows.Forms.DataGridView object.
    bindingSource.DataSource = boundTable;
