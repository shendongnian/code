            private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            if(textbox == null) return;
            var stackPanel = textbox.Parent as StackPanel;
            if(stackPanel == null) return;
            var textBlock = stackPanel.Children.Where(a => a is TextBlock).FirstOrDefault();
            if (textBlock == null) return;
            if (string.IsNullOrEmpty(textbox.Text)) textBlock.Visibility = Visibility.Visible;
            else textBlock.Visibility = Visibility.Collapsed;
        }
