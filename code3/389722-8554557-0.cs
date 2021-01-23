    Bitmap b = new Bitmap(columns, rows, PixelFormat.Format8bppIndexed);
    for (int i = 0; i < columns; i++)
    {
       for (int x = 0; x < rows; x++)
        {
           Color oc = b.GetPixel(i, x);
            int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
           Color nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
           b.SetPixel(i, x, nc);
      }
    }
    BitmapData bmd = b.LockBits(new Rectangle(0, 0, columns, rows), ImageLockMode.ReadWrite, b.PixelFormat);
 
