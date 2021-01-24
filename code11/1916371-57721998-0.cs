    private async void btnConvertImage_ClickAsync(object sender, RoutedEventArgs e)
    {
        var originalImage = ( imgPhotoOriginal.Source as BitmapImage );
        BitmapImage result = await Task.Run( () => originalImage.ToBitmap().ToGrayscale().ToBitmapImage() );
        imgPhotoConverted.Source = result;
    }
