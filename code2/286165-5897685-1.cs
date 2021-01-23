        private void hideBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var child in wp.Children)
            {
                var btn = (Button)child;
                btn.Visibility = Visibility.Visible;
            }
            foreach (var child in wp.Children)
            {
                var btn = (Button)child;
                if (btn.Name.Contains(buttonNumber.Text))
                {
                    if (radioCollapsed.IsChecked.Value)
                        btn.Visibility = Visibility.Collapsed;
                    else
                        btn.Visibility = Visibility.Hidden;
                }
            }
        }
