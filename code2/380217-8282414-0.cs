        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = ((TextBox)sender);
            if (String.IsNullOrEmpty(txt.Text))
            {
                txt.Tag = new SolidColorBrush(Colors.Red);
            }
            else
            {
                txt.Tag = null;
            }
        }
