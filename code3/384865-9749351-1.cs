    private void mainMenu_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender != null)
        {
            ContextMenu menu = sender as ContextMenu;
            if (menu != null)
            {
               // get the visual root for the context menu
               var root = (FrameworkElement)GetVisualTreeRoot(menu);
               // invalidate the menu's layout
               root.InvalidateMeasure();
            }             
        }
    }
