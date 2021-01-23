    static Color[] GetPixelColumnFast(Bitmap bmp, int x)
    {
      Color[] pixelColumn = new Color[bmp.Height];
      BitmapData pixelData = bmp.LockBits(
        new Rectangle(0, 0, bmp.Width, bmp.Height),
        ImageLockMode.ReadOnly,
        PixelFormat.Format32bppArgb);
      unsafe
      {
        int* pData = (int*)pixelData.Scan0.ToPointer();
        pData += x;
        for (int i = 0; i < bmp.Height; ++i)
        {
          pixelColumn[i] = Color.FromArgb(*pData);
          pData += bmp.Width;
        }
      }
      bmp.UnlockBits(pixelData);
      return pixelColumn;
    }
