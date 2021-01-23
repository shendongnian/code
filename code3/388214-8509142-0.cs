            Bitmap bitmap = new Bitmap(this.currentSampleWidth, this.currentSampleHeight, PixelFormat.Format32bppArgb);
            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat);
            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;
            // Declare an array to hold the bytes of the bitmap (32 bits per pixel)
            int pixelsCount = bitmap.Width * bitmap.Height;
            int[] argbValues = new int[pixelsCount];
            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, argbValues, 0, pixelsCount);
            // Set the color value for each pixel.
            for (int counter = 0; counter < argbValues.Length; counter++)
                argbValues[counter] = color.ToArgb();
            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(argbValues, 0, ptr, pixelsCount);
            // Unlock the bits.
            bitmap.UnlockBits(bmpData);
            return bitmap;
