    private async void DataGrid_SOExample_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.EditAction == DataGridEditAction.Commit)
        {
            List<SoExample> soExampList = (this.DataGrid_SOExample.ItemsSource as List<SoExample>);
            soExampList[1].Field1 = DateTime.Now.ToLongDateString();
        }
    }
