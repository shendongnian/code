    private async void StartTest_Click(object sender, RoutedEventArgs e)
    {
        foreach (var button in selectedButtons)
        {
            button.Background = resourceDictionary["ProcessingButtonColour"] as Brush;
            await Task.Delay(3000);
            button.Background = resourceDictionary["HoverOverColourInactive"] as Brush;
        }
    }
