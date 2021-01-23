    public unsafe static Bitmap GetBlueImagePerf(Image sourceImage)
    {
      int width = sourceImage.Width;
      int height = sourceImage.Height;
      Bitmap bmp = new Bitmap(sourceImage);
      Bitmap redBmp = new Bitmap(width, height, bmp.PixelFormat);
      BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
      BitmapData bd2 = redBmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
      byte* source = (byte*)bd.Scan0.ToPointer();
      byte* target = (byte*)bd2.Scan0.ToPointer();
      int stride = bd.Stride;
      Parallel.For(0, height, (y1) =>
      {
        byte* s = source + (y1 * stride);
        byte* t = target + (y1 * stride);
        for (int x = 0; x < width; x++)
        {
          // use t[1], s[1] to access green channel
          // use t[2], s[2] to access red channel
          t[0] = s[0]; 
          t += 4;       // Add bytes per pixel to current position.
          s += 4;       // For other pixel formats this value is different.
        }
      });
      bmp.UnlockBits(bd);
      redBmp.UnlockBits(bd2);
      return redBmp;
    }
    public unsafe static void DoImageConversion()
    {
      Bitmap RedLayer   = GetRedImagePerf(Image.FromFile("image_path1"));
      Bitmap GreenLayer = GetGreenImagePerf(Image.FromFile("image_path2"));
      Bitmap BlueLayer  = GetBlueImagePerf(Image.FromFile("image_path3"));
      Bitmap composite =
        new Bitmap(RedLayer.Width, RedLayer.Height, RedLayer.PixelFormat);      
      BitmapData bd = composite.LockBits(new Rectangle(0, 0, RedLayer.Width, RedLayer.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
      byte* comp = (byte*)bd.Scan0.ToPointer();
      BitmapData bdRed = RedLayer.LockBits(new Rectangle(0, 0, RedLayer.Width, RedLayer.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
      BitmapData bdGreen = GreenLayer.LockBits(new Rectangle(0, 0, RedLayer.Width, RedLayer.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
      BitmapData bdBlue = BlueLayer.LockBits(new Rectangle(0, 0, RedLayer.Width, RedLayer.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
      byte* red = (byte*)bdRed.Scan0.ToPointer();
      byte* green = (byte*)bdGreen.Scan0.ToPointer();
      byte* blue = (byte*)bdBlue.Scan0.ToPointer();
      int stride = bdRed.Stride;
      Parallel.For(0, bdRed.Height, (y1) =>
      {
        byte* r = red + (y1 * stride);
        byte* g = green + (y1 * stride);
        byte* b = blue + (y1 * stride);
        byte* c = comp + (y1 * stride);
        for (int x = 0; x < bdRed.Width; x++)
        {
          c[0] = b[0];
          c[1] = g[1];
          c[2] = r[2];
          r += 4; // Add bytes per pixel to current position.
          g += 4; // For other pixel formats this value is different.
          b += 4; // Use Image.GetPixelFormatSize to get number of bits per pixel
          c += 4;
        }
      });
      
      composite.Save("save_image_path", ImageFormat.Jpeg);
    }
