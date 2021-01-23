    using (Bitmap bmp = (Bitmap)Image.FromFile(@"mybitmap.bmp"))
    {
      int width = bmp.Width;
      int height = bmp.Height;
      BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height),
        System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
      byte* s0 = (byte*)bd.Scan0.ToPointer();
      int stride = bd.Stride;
      Parallel.For(0, height, (y1) =>
      {
        int posY = y1*stride;
        byte* cpp = s0 + posY;
          
        for (int x = 0; x < width; x++)
        {              
          // Set your pixel values here.
          cpp[0] = 255;
          cpp[1] = 255;
          cpp[2] = 255;
          cpp += 3;
        }
      });
      
      bmp.UnlockBits(bd);
    }
