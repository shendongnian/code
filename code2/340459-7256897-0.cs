    private void _dataGrid_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
           _dataGrid.EndEdit();
           int nextIndex = _dataGrid.SelectedIndex + 1;
           //should crash when enter hit after editing last row, so need to check it
           if(nextIndex < _dataGrid.items.Count)
           {
              _dataGrid.SelectedIndex = nextIndex;
              _dataGrid.CurrentItem = _dataGrid.Items[nextIndex];
            }
           _dataGrid.BeginEdit();
        }
    }
