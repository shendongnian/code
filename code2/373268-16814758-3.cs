    private void GotFocusaAction(object sender, System.Windows.RoutedEventArgs e)
        {
            InputUserName.Background = new SolidColorBrush(Colors.Purple);
            InputUserName.BorderBrush = new SolidColorBrush(Colors.Purple);
        }
        private void LostFocusAction(object sender, System.Windows.RoutedEventArgs e)
        {
            InputUserName.Background = new SolidColorBrush(Colors.Red);
            InputUserName.BorderBrush = new SolidColorBrush(Colors.Red);
        }
