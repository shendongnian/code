    public static Bitmap Fill(Bitmap bmp, Color color)
    {
        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        System.Drawing.Imaging.BitmapData bmpData =
            bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
            bmp.PixelFormat);
        IntPtr ptr = bmpData.Scan0;
        int bytes  = Math.Abs(bmpData.Stride) * bmp.Height;
        byte[] rgbValues = new byte[bytes];
        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);  
        for (int i= 0; i< rgbValues.Length; i+= 4)
        {
             rgbValues[i] = color.A;
             rgbValues[i] = color.B;
             rgbValues[i] = color.G;
             rgbValues[i] = color.R;
        }
        System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
        bmp.UnlockBits(bmpData);
        e.Graphics.DrawImage(bmp, 0, 0);
        return bmp;
    }
