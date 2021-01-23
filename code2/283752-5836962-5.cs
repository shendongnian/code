    private void Button1_Click(object sender, RoutedEventArgs e)
    {
        // If the grid is populated via a collection binding the SelectedItem will
        // not be a DataGridRow, but an item from the collection. You need to cast
        //  as necessary. (Of course this can be null if nothing is selected)
    	var row = (DataGridRow)dataGrid.SelectedItem;
    }
