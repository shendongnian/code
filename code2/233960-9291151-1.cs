        private static Bitmap GetBitmapFromHBitmap(IntPtr nativeHBitmap)
        {
            Bitmap bmp = Bitmap.FromHbitmap(nativeHBitmap);
            if (Bitmap.GetPixelFormatSize(bmp.PixelFormat) < 32)
                return bmp;
            BitmapData bmpData;
            if (IsAlphaBitmap(bmp, out bmpData))
                return GetlAlphaBitmapFromBitmapData(bmpData);
            return bmp;
        }
        private static Bitmap GetlAlphaBitmapFromBitmapData(BitmapData bmpData)
        {
            return new Bitmap(
                    bmpData.Width,
                    bmpData.Height,
                    bmpData.Stride,
                    PixelFormat.Format32bppArgb,
                    bmpData.Scan0);
        }
        private static bool IsAlphaBitmap(Bitmap bmp, out BitmapData bmpData)
        {
            Rectangle bmBounds = new Rectangle(0, 0, bmp.Width, bmp.Height);
            bmpData = bmp.LockBits(bmBounds, ImageLockMode.ReadOnly, bmp.PixelFormat);
            try
            {
                for (int y = 0; y <= bmpData.Height - 1; y++)
                {
                    for (int x = 0; x <= bmpData.Width - 1; x++)
                    {
                        Color pixelColor = Color.FromArgb(
                            Marshal.ReadInt32(bmpData.Scan0, (bmpData.Stride * y) + (4 * x)));
                        if (pixelColor.A > 0 & pixelColor.A < 255)
                        {
                            return true;
                        }
                    }
                }
            }
            finally
            {
                bmp.UnlockBits(bmpData);
            }
            return false;
        }
