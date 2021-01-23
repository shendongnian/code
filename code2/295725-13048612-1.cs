    public static class TwainBitmapConvertor
    {
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        private class BitmapInfoHeader
        {
            public int Size;
            public int Width;
            public int Height;
            public short Planes;
            public short BitCount;
            public int Compression;
            public int SizeImage;
            public int XPelsPerMeter;
            public int YPelsPerMeter;
            public int ClrUsed;
            public int ClrImportant;
        }
        [DllImport("gdi32.dll", ExactSpelling = true)]
        private static extern int SetDIBitsToDevice(IntPtr hdc, 
            int xdst, int ydst, int width, int height, int xsrc, 
            int ysrc, int start,  int lines, IntPtr bitsptr, 
            IntPtr bmiptr, int color);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GlobalLock(IntPtr handle);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern bool GlobalUnlock(IntPtr handle);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GlobalFree(IntPtr handle);
        public static Bitmap ToBitmap(IntPtr dibHandle)
        {
            var bitmapPointer = GlobalLock(dibHandle);
            var bitmapInfo = new BitmapInfoHeader();
            Marshal.PtrToStructure(bitmapPointer, bitmapInfo);
            var rectangle = new Rectangle();
            rectangle.X = rectangle.Y = 0;
            rectangle.Width = bitmapInfo.Width;
            rectangle.Height = bitmapInfo.Height;
            if (bitmapInfo.SizeImage == 0)
            {
                bitmapInfo.SizeImage = 
                    ((((bitmapInfo.Width * bitmapInfo.BitCount) + 31) & ~31) >> 3) 
                    * bitmapInfo.Height;
            }
            // The following code only works on x86
            Debug.Assert(Marshal.SizeOf(typeof(IntPtr)) == 4);
            int pixelInfoPointer = bitmapInfo.ClrUsed;
            if ((pixelInfoPointer == 0) && (bitmapInfo.BitCount <= 8))
            {
                pixelInfoPointer = 1 << bitmapInfo.BitCount;
            }
            pixelInfoPointer = (pixelInfoPointer * 4) + bitmapInfo.Size 
                + bitmapPointer.ToInt32();
            IntPtr pixelInfoIntPointer = new IntPtr(pixelInfoPointer);
            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                IntPtr hdc = graphics.GetHdc();
                try
                {
                    SetDIBitsToDevice(hdc, 
                        0, 0, rectangle.Width, rectangle.Height, 0, 0, 0, 
                        rectangle.Height, pixelInfoIntPointer, bitmapPointer, 0);
                }
                finally
                {
                    graphics.ReleaseHdc(hdc);
                }
            }
            bitmap.SetResolution(PpmToDpi(bitmapInfo.XPelsPerMeter),
                PpmToDpi(bitmapInfo.YPelsPerMeter));
            GlobalUnlock(dibHandle);
            GlobalFree(dibHandle);
            return bitmap;
        }
        private static float PpmToDpi(double pixelsPerMeter)
        {
            double pixelsPerMillimeter = (double)pixelsPerMeter / 1000.0;
            double dotsPerInch = pixelsPerMillimeter * 25.4;
            return (float)Math.Round(dotsPerInch, 2);
        }
    }
