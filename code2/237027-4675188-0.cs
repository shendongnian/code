    var image = new byte[] {255,255,255,0,0,0,255,255,255,
                            0,0,0,255,127,255,0,0,0,
                            255,255,255,0,0,0,255,255,255};
    Bitmap bmp = new Bitmap(2, 2, PixelFormat.Format24bppRgb);
    BitmapData bmpData = bmp.LockBits(
                            new Rectangle(0, 0, bmp.Width, bmp.Height),
                            ImageLockMode.WriteOnly, bmp.PixelFormat);
    Marshal.Copy(image, 0, bmpData.Scan0, image.Length);
    bmp.UnlockBits(bmpData);
    var testPixel = bmp.GetPixel(1, 1);
