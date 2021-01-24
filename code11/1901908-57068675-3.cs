    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var image = (Image)button.Content;
        var imOff = (ImageSource)FindResource("ImOFF");
        if (image.Source == imOff)
        {
            image.Source = (ImageSource)FindResource("ImON");
            button.IsEnabled = false;
 
            await Task.Run(() => ThingsToDo());
            button.IsEnabled = true;
        }
        else
        {
            image.Source = imOff;
        }
    }
