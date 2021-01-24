    private async void StartTest_Click(object sender, RoutedEventArgs e)
    {
        foreach (var button in selectedButtons)
        {
            bSelected.Background = resourceDictionary["ProcessingButtonColour"] as Brush;
            await Task.Delay(3000);
            bSelected.Background = resourceDictionary["HoverOverColourInactive"] as Brush;
        }
    }
