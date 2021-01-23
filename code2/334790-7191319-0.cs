    public List<MemoryStream> ImageStreams {get; private set;}
    public static ImageSource StreamToImageSource(Stream stream)
    {
        BitmapImage bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = stream;
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.DecodePixelHeight = 200;
        bitmapImage.EndInit();
        bitmapImage.Freeze();
        return bitmapImage;
    }
