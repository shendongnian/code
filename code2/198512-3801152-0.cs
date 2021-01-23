    void _gridObj_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        e.Row.MouseLeftButtonUp -= new MouseButtonEventHandler(Row_MouseLeftButtonUp);
        e.Row.MouseLeftButtonUp += new MouseButtonEventHandler(Row_MouseLeftButtonUp);
    }
