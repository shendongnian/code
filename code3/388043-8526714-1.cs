    private void moveToFav_Loaded(object sender, RoutedEventArgs e)
        {
            if (condition)
                (sender as MenuItem).IsEnabled = false;
        }
        private void copyToFav_Loaded(object sender, RoutedEventArgs e)
        {
            if (condition)
                (sender as MenuItem).IsEnabled = false;
        }
