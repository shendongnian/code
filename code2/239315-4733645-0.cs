public static byte[] ConvertToBytes(this BitmapImage bitmapImage)
{
    byte[] data = null;
    using (MemoryStream stream = new MemoryStream())
    {
        WriteableBitmap wBitmap = new WriteableBitmap(bitmapImage);
        wBitmap.SaveJpeg(stream, wBitmap.PixelWidth, wBitmap.PixelHeight, 0, 100);
        stream.Seek(0, SeekOrigin.Begin);
        data = stream.GetBuffer();
    }
    return data;
}
