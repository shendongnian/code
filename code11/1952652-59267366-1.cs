    private void DgLogs_OnInitialized(object sender, EventArgs e)
    {
        if (!(sender is DataGrid grid)) return;
            
        //Column with index 1 will be hidden.
        grid.Columns[1].Visibility = Visibility.Hidden;
        //Column with header = Data2 will be hidden
        var column = grid.Columns.FirstOrDefault(c => c.Header.Equals("Data2"));
        column.Visibility = Visibility.Hidden;
    }
