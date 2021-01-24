    // Here we initlialize a DataGridView
    DataGridView dg = new DataGridView();
    dg.DataSource = new DataTable();
    // Now we bind a Method to the CellValueChanged-Event:
    dg.CellValueChanged += TrackChanges;
