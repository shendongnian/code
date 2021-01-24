        private void webviewtest_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            if (tb.SelectedText.Length > 0)
            {
                Item.Text = tb.SelectedText;
            }
            // Show at cursor position
            Flyout.ShowAt(sender as UIElement, e.GetPosition(sender as UIElement));
        }
