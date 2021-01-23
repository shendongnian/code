    int width = 20, height = 41;
    byte[] grayscale_image = {0, 0, 0, ...};
    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(width, height, PixelFormat.Format8bppIndexed);
    
    System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(
                         new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                         ImageLockMode.WriteOnly, bitmap.PixelFormat);
    
    System.Runtime.InteropServices.Marshal.Copy(bytes, 0, bmpData.Scan0, bytes.Length);
    
    bitmap.UnlockBits(bmpData);
    
    return bitmap;
