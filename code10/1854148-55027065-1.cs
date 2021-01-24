    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        MenuItem mi = (MenuItem)sender;
        ContextMenu cm = mi.Parent as ContextMenu;
        if (cm != null)
        {
            FrameworkElement fe = cm.PlacementTarget as FrameworkElement;
            if (fe != null)
            {
                object dataItem = fe.DataContext;
                //...
            }
        }
    }
