    private void DrawUI(byte[] frameBody)
    {
        try
        {
            var bitmap = new BitmapImage();
            using (var stream = new MemoryStream(frameBody))
            {
                bitmap.BeginInit();
                bitmap.DecodePixelWidth = 1080;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
            }
            image.Source = bitmap;
        }
        catch (Exception e)
        {
            Debug.WriteLine($"catch a exception {e.Message}");
        }
    }
