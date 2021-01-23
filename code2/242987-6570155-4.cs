        private byte[] BitmapToByteArray2(Bitmap bmp)
        {
            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, ImageLockMode.ReadOnly,
                bmp.PixelFormat);
            int absStride = Math.Abs(bmpData.Stride);
            int bytes = absStride * bmp.Height;
            // Declare an array to hold the bytes of the bitmap.
            byte[] rgbValues = new byte[bytes];
            for (int i = 0; i < bmp.Height; i++)
            {
                IntPtr pointer = new IntPtr(bmpData.Scan0.ToInt32() + (bmpData.Stride * i));
                System.Runtime.InteropServices.Marshal.Copy(pointer, rgbValues, absStride * (bmp.Height - i - 1), absStride);
            }
            // Unlock the bits.
            bmp.UnlockBits(bmpData);
            return rgbValues;
        }
