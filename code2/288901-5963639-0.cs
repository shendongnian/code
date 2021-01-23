        public void SomeStuff(Bitmap image)
        {
            var imageWidth = image.Width;
            var imageHeight = image.Height;
            var imageData = image.LockBits(new Rectangle(0, 0, imageWidth, imageHeight), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            var imageByteCount = imageData.Stride*imageData.Height;
            var imageBuffer = new byte[imageByteCount];
            Marshal.Copy(imageData.Scan0, imageBuffer, 0, imageByteCount);
            for (int x = 0; x < imageWidth; x++)
            {
                for (int y = 0; y < imageHeight; y++)
                {
                    var pixelColor = GetPixel(imageBuffer, imageData.Stride, x, y);
                    // Do your stuff
                }
            }
        }
        private static Color GetPixel(byte[] imageBuffer, int imageStride, int x, int y)
        {
            int pixelBase = y*imageStride + x*3;
            byte blue = imageBuffer[pixelBase];
            byte green = imageBuffer[pixelBase + 1];
            byte red = imageBuffer[pixelBase + 2];
            return Color.FromArgb(red, green, blue);
        }
