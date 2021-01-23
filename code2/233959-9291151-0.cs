        private static Bitmap GetBitmapFromHBitmap(IntPtr nativeHBitmap)
        {
            Bitmap bmp = Bitmap.FromHbitmap(nativeHBitmap);
            if (Bitmap.GetPixelFormatSize(bmp.PixelFormat) < 32)
                return bmp;
            Rectangle bmBounds = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(bmBounds, ImageLockMode.ReadOnly, bmp.PixelFormat);
            bool isAlphaBitmap = IsAlphaBitmap(bmpData);
            bmp.UnlockBits(bmpData);
            if (isAlphaBitmap)
                return GetlAlphaBitmapFromBitmapData(bmpData);
            else
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
        private static bool IsAlphaBitmap(BitmapData bmData)
        {
            for (int y = 0; y <= bmData.Height - 1; y++)
            {
                for (int x = 0; x <= bmData.Width - 1; x++)
                {
                    Color pixelColor = Color.FromArgb(
                        Marshal.ReadInt32(bmData.Scan0, (bmData.Stride * y) + (4 * x)));
                    if (pixelColor.A > 0 & pixelColor.A < 255)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
