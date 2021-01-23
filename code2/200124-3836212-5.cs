    private void dg_Loaded(object sender, RoutedEventArgs e)
    {
        if ((dg.Items.Count > 0) &&
            (dg.Columns.Count > 0))
        {
            //Select the first column of the first item.
            dg.CurrentCell = new DataGridCellInfo(dg.Items[0], dg.Columns[0]);
            dg.SelectedCells.Add(dg.CurrentCell);
        }
    }
