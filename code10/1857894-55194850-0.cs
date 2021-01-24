    private async Task<BitmapImage> LoadWebP(string url)
    {
        var httpClient = new HttpClient();
        var buffer = await httpClient.GetByteArrayAsync(url);
        var decoder = new Imazen.WebP.SimpleDecoder();
        var bitmapImage = new BitmapImage();
        using (var stream1 = new MemoryStream(buffer))
        {
            var bitmap = decoder.DecodeFromBytes(buffer, buffer.Length);
            using (var stream2 = new MemoryStream())
            {
                bitmap.Save(stream2, System.Drawing.Imaging.ImageFormat.Png);
                stream2.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream2;
                bitmapImage.EndInit();
            }
        }
        return bitmapImage;
    }
