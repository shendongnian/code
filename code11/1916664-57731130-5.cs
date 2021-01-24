    base64String = File.ReadAllText(base64File);
    buffer = System.Convert.FromBase64String(base64String);
    using (var stream = new MemoryStream(buffer))
    {
        image2.Source = BitmapFrame.Create(
            stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
    }
