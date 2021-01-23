    static void MenuItemClicked(object sender, RoutedEventArgs e)
    {
        var menuItem = e.OriginalSource as MenuItem;
        if (menuItem.IsChecked)
        {
            foreach (var item in ElementToGroupNames)
            {
                if (item.Key != menuItem && item.Value == GetGroupName(menuItem))
                {
                    item.Key.IsChecked = false;
                }
            }
        }
        else // it's not possible for the user to deselect an item
        {
            menuItem.IsChecked = true;
        }
    }
