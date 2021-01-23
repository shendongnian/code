    public ListViewItem GetRow(DependencyObject item)
    {
        DependencyObject dObj = VisualTreeHelper.GetParent(item);
        if (dObj == null)
            return null;
        if (dObj is ListViewItem)
            return dObj as ListViewItem;
        return GetRow(dObj);
    }
