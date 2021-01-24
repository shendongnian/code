    private void BackgroundWorker2_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        for (int i = 1; i <= 7; i++)
            DataTable1.Columns.Add();
        for (int i = 1; i <= 1048576; i++)
            DataTable1.Rows.Add(i);
        var dv = DataTable1.DefaultView; //generating the default view takes ~ 2-3 sec.
        Dispatcher.Invoke(() =>
        {
            DataGrid1.ItemsSource = dv;
        });
    }
