    private void OnPageLoaded(object sender, RoutedEventArgs e)
    {
        foreach (var item in FirstChars.Children)
        {
            if (item is ToggleButton button && button.Content.ToString().Equals("A"))
            {
                button.IsChecked = true;
                // Perform your query here or call the appropriate method
                break;
            }
        }
    }
