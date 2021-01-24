    private void Download(object sender, RoutedEventArgs e)
    {
        MenuItem menuItem = e.Source as MenuItem;
        ContextMenu menu = menuItem.Parent as ContextMenu;
        ListViewItem item = menu.PlacementTarget as ListViewItem;
       if (item != null)
       {
           Console.WriteLine(item.Name);
       }
    }
