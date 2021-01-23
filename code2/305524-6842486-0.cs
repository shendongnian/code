    private void DataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Check if the user double-clicked a grid row and not something else
            if (e.OriginalSource == null) return;
            var row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;
            // If so, go ahead and do my thing
            if (row != null)
            {
                var Item = (CLASS_YOU_USE_TO_BIND)DataGrid1.Items[row.GetIndex()];
    //Here you can work with Item, it is now the object of class you used in
    //DataGrid.DataSource
            }
    }
