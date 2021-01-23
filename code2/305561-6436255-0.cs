    public static BitmapSource ConvertByteArrayToBitmapSource(Byte[] imageBytes)
    {
        using (MemoryStream stream = new MemoryStream(imageBytes))
        {
            BitmapDecoder deconder = BitmapDecoder.Create(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            BitmapFrame frame = deconder.Frames.First();
    
            frame.Freeze();
            return frame;
        }
    }
