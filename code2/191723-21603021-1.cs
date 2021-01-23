        private void MenuItem_OnClickDisallowUnselect(object sender, RoutedEventArgs e)
        {
            var menuItem = e.OriginalSource as MenuItem;
            if (menuItem == null) return;
            if (! menuItem.IsChecked)
            {
                menuItem.IsChecked = true;
            }
        }
