    private void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var selectedItemNext = (e.OriginalSource as FrameworkElement).DataContext;
        var selectedItemNow = dataGrid.SelectedItem;
        if (selectedItemNext != selectedItemNow)
            if (!IsValid(sender as DependencyObject))
                e.Handled = true;
    }    
    public bool IsValid(DependencyObject parent)
    {
        if (Validation.GetHasError(parent))
            return false;
        for (int i = 0; i != VisualTreeHelper.GetChildrenCount(parent); ++i)
            if (!IsValid(VisualTreeHelper.GetChild(parent, i)))
                return false;
        return true;
    }
