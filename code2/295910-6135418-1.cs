    Bitmap bmp = new Bitmap("SomeImage");
    
    // Lock the bitmap's bits.  
    Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite,
                                      PixelFormat.Format24bppRgb);
    
    // Get the address of the first line.
    IntPtr ptr = bmpData.Scan0;
    
    // Declare an array to hold the bytes of the bitmap.
    int bytes = bmpData.Stride * bmp.Height;
    byte[] rgbValues = new byte[bytes];
                       
    // Copy the RGB values into the array.
    Marshal.Copy(ptr, rgbValues, 0, bytes);
