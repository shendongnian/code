    private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0)
        {
            object x = e.AddedItems[0];
            if (x is MyObjectType && x != myViewModel.CurrentItem &&
                myViewModel.ShouldNotDeselectCurrentItem())
            {
                // this will actually revert the SelectedItem correctly, but it won't highlight the correct (old) row.
                this.MyDataGrid.SelectedItem = null;
                this.MyDataGrid.SelectedItem = myViewModel.CurrentItem; 
            }
        }
    }
