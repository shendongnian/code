    private System.Drawing.Bitmap BitmapFromSource(BitmapSource bitmapsource)
    {
      System.Drawing.Bitmap bitmap;
      using (MemoryStream outStream = new MemoryStream())
      {
        BitmapEncoder enc = new BmpBitmapEncoder();
        enc.Frames.Add(BitmapFrame.Create(bitmapsource));
        enc.Save(outStream);
        bitmap = new System.Drawing.Bitmap(outStream);
      }
      return bitmap;
    }
