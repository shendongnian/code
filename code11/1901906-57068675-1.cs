    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var image = (Image)button.Content;
        var imOff = (ImageSource)FindResource("ImOFF");
        if (image.Source == imOff)
        {
            image.Source = (ImageSource)FindResource("ImON");
            await Task.Run(() => ThingsToDo());
        }
        else
        {
            image.Source = imOff;
        }
    }
