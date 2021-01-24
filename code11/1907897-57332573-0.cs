        private void changeControl_Click(object sender, RoutedEventArgs e)
        {
            // Add check to see if the existing view is already being displayed so we do not try to add load it again.
            grid1.Children.Clear();
            UIElement uIElement = new UserControl3();
            grid1.Children.Add(uIElement);
        }
