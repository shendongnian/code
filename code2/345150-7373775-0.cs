    var bitmapData = bmp.LockBits(...);
    var length = bitmapData.Stride * bitmapData.Height;
    byte[] bytes = new byte[length];
    // Copy bitmap to byte[]
    Marshal.Copy(bitmapData.Scan0, bytes, 0, length);
    bitmapData.UnlockBits(bData);
