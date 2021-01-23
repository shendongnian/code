    public static byte[] BitmapToByteArray(Bitmap bitmap)
    {
    
        try
        {
            BitmapData bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            int numbytes = bmpdata.Stride * bitmap.Height;
            byte[] bytedata = new byte[numbytes];
            IntPtr ptr = bmpdata.Scan0;
    
            Marshal.Copy(ptr, bytedata, 0, numbytes);
        }
        finally
        {
            bitmap.UnlockBits(bmpdata);
        }
    
        return bytedata;
    
    }
.
