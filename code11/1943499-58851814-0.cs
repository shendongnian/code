    private Task<DataView> GetDataAsync()
        {
            return Task.Run(() =>
            {
                for (int i = 1; i <= 7; i++)
                    DataTable1.Columns.Add();
                for (int i = 1; i <= 1048576; i++)
                    DataTable1.Rows.Add(i);
                return DataTable1.DefaultView;
            });
        }
     private  void BackgroundWorker2_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Dispatcher.Invoke((Action)(async () =>
            {
                DataGrid1.ItemsSource = await GetDataAsync();
            }));
        }
