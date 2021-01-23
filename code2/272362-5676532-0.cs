    foreach (DataGridColumn c in dg.Columns)
        c.Width = 0;
    
    // Update your DG's source here
    
    foreach (DataGridColumn c in dg.Columns)
        c.Width = DataGridLength.Auto;
