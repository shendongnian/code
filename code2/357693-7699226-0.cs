    static Color[] GetPixelColumn(Bitmap bmp, int x)
    {
      Color[] pixelColumn = new Color[bmp.Height];
      for (int i = 0; i < bmp.Height; ++i)
      {
        pixelColumn[i] = bmp.GetPixel(x, i);
      }
      return pixelColumn;
    }
