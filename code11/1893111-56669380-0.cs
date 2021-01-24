    private void Port_selected(object sender, RoutedEventArgs e)
    {
        Button btn = (Button)sender;
        StackPanel stackPanel = btn.Parent as StackPanel;
        if (stackPanel != null)
        {
            TextBlock textBlock = stackPanel.Children
                .OfType<TextBlock>()
                .FirstOrDefault(x => !string.IsNullOrEmpty(x.Name));
            if (textBlock != null)
            {
                string name = textBlock.Name;
                //...
            }
        }
    }
