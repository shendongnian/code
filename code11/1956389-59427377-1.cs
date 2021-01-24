    private void GridContextMenuOpening(object sender, ContextMenuEventArgs e)
    {
        DataGridCell cell;
        DataGridRow row;
        var dep = DataGridMiscHelpers.FindVisualParentAsDataGridSubComponent(
            (DependencyObject)e.OriginalSource);
        if (dep == null)
        {
            return;
        }
        DataGridMiscHelpers.FindCellAndRow(dep, out cell, out row);
        if (dep is DataGridColumnHeader || dep is DataGridRow)
        {
            e.Handled = true;
            return;
        }
        // Hide/show the menu items depending on the cell and/or row clicked.
        // (You could programmatically add/remove menu items here instead).
        mnuOpen.Visibility = (cell.Column.Header == "whatever") ? Visibility.Hidden : Visibility.Visible;
        mnuNew.Visibility = ((row.Item as MyViewModel).SomeProperty == 123) ? Visibility.Hidden : Visibility.Visible;
    }
