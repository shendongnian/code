    private void Download(object sender, RoutedEventArgs e)
    {
        // Note: In this case, the `sender` parameter is the MenuItem as well.
        // MenuItem menuItem = sender as MenuItem
        MenuItem menuItem = e.Source as MenuItem;
        ContextMenu menu = menuItem.Parent as ContextMenu;
        ListViewItem item = menu.PlacementTarget as ListViewItem;
       if (item != null)
       {
           Console.WriteLine(item.Name);
       }
    }
