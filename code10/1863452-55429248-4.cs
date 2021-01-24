    var imageFileEntry = archive.GetEntry(image.Tag.ToString());
    if (imageFileEntry != null)
    {
        using (var imageFileStream = imageFileEntry.Open())
        using (var memoryStream = new MemoryStream())
        {
            imageFileStream.CopyTo(memoryStream);
            memoryStream.Position = 0;
            image.Source = BitmapFrame.Create(
                memoryStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }
    }
