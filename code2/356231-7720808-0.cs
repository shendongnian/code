        public Bitmap Lighten(Bitmap bitmap, int amount)
    {
      if (amount < -255 || amount > 255)
        return bitmap;
      // GDI+ still lies to us - the return format is BGR, NOT RGB.
      BitmapData bmData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
      int stride = bmData.Stride;
      System.IntPtr Scan0 = bmData.Scan0;
      int nVal = 0;
      unsafe
      {
        byte* p = (byte*)(void*)Scan0;
        int nOffset = stride - bitmap.Width * 3;
        int nWidth = bitmap.Width * 3;
        for (int y = 0; y < bitmap.Height; ++y)
        {
          for (int x = 0; x < nWidth; ++x)
          {
            nVal = (int)(p[0] + amount);
            if (nVal < 0) nVal = 0;
            if (nVal > 255) nVal = 255;
            p[0] = (byte)nVal;
            ++p;
          }
          p += nOffset;
        }
      }
      bitmap.UnlockBits(bmData);
      return bitmap;
    }
    private void btnLighten_Click(object sender, EventArgs e)
    {
      Bitmap image = pictureBox1.Image as Bitmap;
      pictureBox1.Image = Lighten(image, 10);
    }
    private void btnDarken_Click(object sender, EventArgs e)
    {
      Bitmap image = pictureBox1.Image as Bitmap;
      pictureBox1.Image = Lighten(image, -10);
    }
