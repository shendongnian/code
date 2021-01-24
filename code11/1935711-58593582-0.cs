    StorageFile storageFile = StorageFile.GetFileFromPathAsync(filePath).AsTask().GetAwaiter().GetResult();
    IRandomAccessStreamWithContentType random = storageFile.OpenReadAsync().AsTask().GetAwaiter().GetResult();
    BitmapDecoder decoder = BitmapDecoder.CreateAsync(random).AsTask().GetAwaiter().GetResult();
    
    // here is the catch
    PixelDataProvider pixelData = decoder.GetPixelDataAsync(
        BitmapPixelFormat.Rgba8, // <--- you must to get the pixels like this
        BitmapAlphaMode.Straight,
        new BitmapTransform(),
        ExifOrientationMode.RespectExifOrientation,
        ColorManagementMode.DoNotColorManage // <--- you must to set this too
    ).AsTask().GetAwaiter().GetResult();
