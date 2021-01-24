    private async void saveButton_Click(object sender, RoutedEventArgs e)
    {
        RenderTargetBitmap rtb = new RenderTargetBitmap();
        await rtb.RenderAsync(myGrid);
        var pixelBuffer = await rtb.GetPixelsAsync();
        var pixels = pixelBuffer.ToArray();
        var displayInformation = DisplayInformation.GetForCurrentView();
        var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("testImage" + ".png", CreationCollisionOption.ReplaceExisting);
        using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
        {
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
            encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                                 BitmapAlphaMode.Premultiplied,
                                 (uint)rtb.PixelWidth,
                                 (uint)rtb.PixelHeight,
                                 displayInformation.RawDpiX,
                                 displayInformation.RawDpiY,
                                 pixels);
            await encoder.FlushAsync();
        }
    }
