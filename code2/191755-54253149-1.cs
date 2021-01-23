        private static void MenuItemUnchecked(object sender, RoutedEventArgs e)
        {
            if (!(e.OriginalSource is MenuItem menuItem))
                return;
            var isAnyItemChecked = ElementToGroupNames.Any(item => item.Value == GetGroupName(menuItem) && item.Key.IsChecked);
            if (!isAnyItemChecked)
                menuItem.IsChecked = true;
        }
