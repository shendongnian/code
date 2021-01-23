    private void bt_click(object sender, RoutedEventArgs e)
    {
        MenuItem clickedMenuItem = sender as MenuItem;
        ContextMenu contextMenu = clickedMenuItem.Parent as ContextMenu;
        DockPanel dockPanel = contextMenu.PlacementTarget as DockPanel;
        ListBoxItem listBoxItem = GetVisualParent<ListBoxItem>(dockPanel);
        MessageBox.Show(listBoxItem.ToString());
    }
    public static T GetVisualParent<T>(object childObject) where T : Visual
    {
        DependencyObject child = childObject as DependencyObject;
        // iteratively traverse the visual tree
        while ((child != null) && !(child is T))
        {
            child = VisualTreeHelper.GetParent(child);
        }
        return child as T;
    }
