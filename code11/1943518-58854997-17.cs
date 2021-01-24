    private async void BackgroundWorker2_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      for (int columnIndex = 0; columnIndex < 7; columnIndex++)
      {
        await Application.Current.Dispatcher.InvokeAsync(
          () =>
          {
            var textColumn = new DataGridTextColumn
            {
              Header = $"Column {columnIndex + 1}", 
              Binding = new Binding($"ColumnItems[{columnIndex}].Value")
            };
            this.DataGrid1.Columns.Add(textColumn);
          },
          DispatcherPriority.Background);
      }
      for (int rowCount = 0; rowCount <= 1048576; rowCount++)
      {
        int count = rowCount;
        await Application.Current.Dispatcher.InvokeAsync(() =>
        {
          var rowItem = new RowItem();
          for (; count < 7 + rowCount; count ++)
          {
            rowItem.ColumnItems.Add(new ColumnItem((int) Math.Pow(2, count)));
          }
          this.DataTableRowCollection.Add(rowItem);
        }, DispatcherPriority.Background);
      }
    }
    private void AddColumn_OnClick(object sender, RoutedEventArgs e)
    {
      int newColumnIndex = this.DataTableRowCollection.First().ColumnItems.Count;
      this.DataGrid1.Columns.Add(
        new DataGridTextColumn()
        {
          Header = $"Dynamically Added Column {newColumnIndex}",
          Binding = new Binding($"ColumnItems[{newColumnIndex}].Value")
        });
      int rowCount = 0;
      foreach (RowItem rowItem in this.DataTableRowCollection)
      {
        var columnItem = new ColumnItem((int) Math.Pow(2, newColumnIndex) * ++rowCount);
        rowItem.ColumnItems.Add(columnItem);
      }
    }
