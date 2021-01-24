    BitmapImage bi = new BitmapImage();
    using (var stream = new MemoryStream(blob))
    {
        bi.BeginInit();
        bi.CacheOption = BitmapCacheOption.OnLoad;
        bi.StreamSource = stream;
        bi.EndInit();
    }
    image2.Source = bi;
