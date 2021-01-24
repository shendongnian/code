    public Bitmap GetBitmapFromRawData(int w, int h, byte[] data)
    {
      Bitmap bmp = new Bitmap(w, h);
      int i = 0;
      for ( int y = 0; y < h; y++ )
      {
        for ( int x = 0; x < w; x++ )
        {
          int a = 255;
          int r = data[i];
          int g = data[i + 1];
          int b = data[i + 2];
          bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
          i += 3;
        }
      }
      return bmp;
    }
