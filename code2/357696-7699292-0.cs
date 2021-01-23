        private static byte[, ,] BitmapToBytes(Bitmap bitmap)
        {
            BitmapData bitmapData = 
                bitmap.LockBits(new Rectangle(new Point(), bitmap.Size), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            byte[] bitmapBytes;
            try
            {
                int byteCount = bitmapData.Stride*bitmap.Height;
                bitmapBytes = new byte[byteCount];
                Marshal.Copy(bitmapData.Scan0, bitmapBytes, 0, byteCount);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);                
            }
            byte[, ,] result = new byte[3, bitmap.Width, bitmap.Height];
            for (int k = 0; k < 3; k++)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        result[k, i, j] = bitmapBytes[j * bitmap.Width * 3 + i * 3 + k];
                    }
                }
            }
            return result;
        }
