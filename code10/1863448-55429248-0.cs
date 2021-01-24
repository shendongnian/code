    var imageFileEntry = archive.GetEntry(image.Tag.ToString());
    if (imageFileEntry != null)
    {
        var bitmap = new BitmapImage();
        using (var imageFileStream = imageFileEntry.Open())
        using (var memoryStream = new MemoryStream())
        {
            imageFileStream.CopyTo(memoryStream);
            memoryStream.Position = 0; // here
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = memoryStream;
            bitmap.EndInit();
        }
        image.Source = bitmap;
    }
