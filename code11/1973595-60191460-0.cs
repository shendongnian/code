    private async void ImageName_TouchDown(object sender, TouchEventArgs e)
    {
        BitmapImage image = new BitmapImage(new Uri("c:/3.jpg", UriKind.Absolute));
        ImageName.Source =image;
        await Task.Delay(2000);
        image = new BitmapImage(new Uri("c:/4.jpg", UriKind.Absolute));
        ImageName.Source = image;
    }
