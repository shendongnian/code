    public static byte[] ConvertToBytes(this BitmapImage bitmapImage)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            WriteableBitmap btmMap = new WriteableBitmap
                (bitmapImage.PixelWidth, bitmapImage.PixelHeight);
    
            // write an image into the stream
            Extensions.SaveJpeg(btmMap, ms,
                bitmapImage.PixelWidth, bitmapImage.PixelHeight, 0, 100);
            
            return ms.ToArray();
        }
    }
