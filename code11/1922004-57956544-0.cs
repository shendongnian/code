    RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();
    await renderTargetBitmap.RenderAsync(MyGrid, MyGrid.ActualWidth, MyGrid.ActualHeight);
    var pixelBuffer = await renderTargetBitmap.GetPixelsAsync();
    var pixels = pixelBuffer.ToArray();
    var displayInformation = DisplayInformation.GetForCurrentView();
    var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Images", CreationCollisionOption.OpenIfExists);
    var file = await folder.CreateFileAsync("RotatedImage" + ".png", CreationCollisionOption.ReplaceExisting);
    using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
    {
        var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
        encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Cubic;
        encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied, (uint)renderTargetBitmap.PixelWidth, (uint)renderTargetBitmap.PixelHeight, displayInformation.RawDpiX, displayInformation.RawDpiY, pixels);
        await encoder.FlushAsync();
    }
