    private void webviewtest_SelectionChanged(object sender, RoutedEventArgs e)
    {
       TextBlock tb = sender as TextBlock;
       if (tb.SelectedText.Length > 0)
       {
           FlyItem.Text = tb.SelectedText;
       }
       // Show at TextBlock Location
       Flyout.ShowAt(webviewtest);
    }
