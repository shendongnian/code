    private void DataGrid_EventName(object sender, SelectionChangedEventArgs e)
    {
      DataGrid _dataGrid = (DataGrid)sender;
      DataRowView selectedRow = _dataGrid.SelectedItem as DataRowView;
    
      RowItemList = new List<string>(); //List declared outside of this method...
      //add row information to the list
      RowItemList.Add(selectedRow);
    }
