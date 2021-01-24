    private async Task<BitmapImage> LoadWebP(string url)
    {
        var httpClient = new HttpClient();
        var buffer = await httpClient.GetByteArrayAsync(url);
        var decoder = new Imazen.WebP.SimpleDecoder();
        var bitmapImage = new BitmapImage();
    private async Task<BitmapImage> LoadWebP(string url)
    {
        var httpClient = new HttpClient();
        var buffer = await httpClient.GetByteArrayAsync(url);
        var decoder = new Imazen.WebP.SimpleDecoder();
        var bitmap = decoder.DecodeFromBytes(buffer, buffer.Length);
        var bitmapImage = new BitmapImage();
        using (var stream = new MemoryStream())
        {
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Position = 0;
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
        }
        return bitmapImage;
    }
