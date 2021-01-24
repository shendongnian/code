    DrawingImage dImageSource = new DrawingImage(dGroup);
    using (MemoryStream ms = new MemoryStream())
    {
        PngBitmapEncoder encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(ToBitmapSource(dImageSource)));
        encoder.Save(ms);
        using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms))
        {
            bmpOut = new System.Drawing.Bitmap(bmp);
        }
    }
