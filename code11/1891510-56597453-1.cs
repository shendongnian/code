    private void DrawUI(byte[] frameBody)
    {
        try
        {
            var bms = (BitmapSource)new ImageSourceConverter().ConvertFrom(frameBody);
            image.Source = bms;
        }
        catch (Exception e)
        {
            Debug.WriteLine($"catch a exception {e.Message}");
        }
    }
