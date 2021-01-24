        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var cb in stk.Children.OfType<CheckBox>())
            {
                cb.IsChecked = !cb.IsChecked;
            }
        }
