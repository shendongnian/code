    private void BgColorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ListView view = (ListView)sender;
        var selected = view.SelectedItem;
        var container = view.ContainerFromItem(selected);
        if (container != null)
        {
            Ellipse ellipse = FindVisualChild<Ellipse>(container);
            if (ellipse != null)
            {
                //...
            }
        }
    }
    private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(obj, i);
            if (child != null && child is T)
                return (T)child;
            else
            {
                T childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                    return childOfChild;
            }
        }
        return null;
    }
