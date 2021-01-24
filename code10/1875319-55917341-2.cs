    using (var bmp = new Bitmap(@"D:\Test.png"))
    {
       var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppPArgb);
       var white = Color.White.ToArgb();
       var black = Color.Black.ToArgb();
    
       try
       {
          var length = (int*)data.Scan0 + bmp.Height * bmp.Width;
          for (var p = (int*)data.Scan0; p < length; p++)
             if (*p != black) *p = white;
       }
       finally
       {
          // unlock the bitmap
          bmp.UnlockBits(data);
          bmp.Save(@"D:\Output.Bmp", ImageFormat.Bmp);
       }
    }
