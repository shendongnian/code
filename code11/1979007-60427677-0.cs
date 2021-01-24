     Object _SelectedItem; //_SelectedItem is used to avoid the repeated loops
        DataGridCell _FocusedCell; //_FocusedCell is used to restore focus
        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_SelectedItem == MyDataGrid.SelectedItem)
            {
                return;
            }
            _SelectedItem = MyDataGrid.SelectedItem;
            if (e.RemovedItems.Count > 0 && e.RemovedItems[0] != null && MessageBox.Show("Are you sure you want save changes?", "Confirm", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                _SelectedItem = e.RemovedItems[0];
                Dispatcher.BeginInvoke(
                  new Action(() =>
                  {
                      MyDataGrid.SelectedItem = e.RemovedItems[0];
                      if (_FocusedCell != null)
                      {
                          _FocusedCell.Focus();
                      }
                  }), System.Windows.Threading.DispatcherPriority.Send); //hope a high priority can avoid flicking.
            }
        }
        private void DataGridCell_LostFocus(object sender, RoutedEventArgs e)
        {
            _FocusedCell = sender as DataGridCell;
        }
