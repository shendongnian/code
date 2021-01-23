    public static byte[] BitmapToByteArray(Bitmap bitmap)
    {
    
        int numbytes = bitmap.Stride * bitmap.Height;
        byte[] bytedata = new byte[numbytes];
    
        BitmapData bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
        IntPtr ptr = bmpdata.Scan0;
    
        Marshal.Copy(ptr, bytedata, 0, numbytes);
    
        bitmap.UnlockBits(bmpdata);
    
        return bytedata;
    
    }
.
