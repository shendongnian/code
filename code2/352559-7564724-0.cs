     private void AddContextMenu(MenuItem item)
     {
        MenuItem item1 = new MenuItem();
        ....
        ContextMenu menu = new ContextMenu();
        ....
        menu.PlacementTarget = item;   /// 'Connects' context menu to source menu item.
        item.ContextMenu = menu;
     } 
     void item_Click(object sender, RoutedEventArgs e)
     {
        MenuItem item = sender as MenuItem;
        string header
           = ((MenuItem)((ContextMenu)((MenuItem)sender).Parent).PlacementTarget).Header;
     }  
