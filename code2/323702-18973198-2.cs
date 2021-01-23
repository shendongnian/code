    private void MyDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
    {
        List<DataGridCellInfo> selectedCells = MyDataGrid.SelectedCells.ToList();
        List<MyObjectType> wrongObjects = selectedCells.Select(cellInfo => cellInfo.Item as MyObjectType)
            .Where (myObject => myObject != myViewModel.CurrentItem).Distinct().ToList();
        if (wrongObjects.Count > 0)
        {
            MyDataGrid.UnselectAllCells();
            MyDataGrid.SelectedItem = null;
            MyDataGrid.SelectedItem = myViewModel.CurrentItem;
        }
    }
