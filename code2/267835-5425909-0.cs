        public void FillPngWhite(Bitmap bmp)
        {
            if (bmp.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ApplicationException("Not supported PNG image!");
            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;
            // Declare an array to hold the bytes of the bitmap.
            int bytes  = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbaValues = new byte[bytes];
            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbaValues, 0, bytes);
            // array consists of values RGBARGBARGBA
            for (int counter = 0; counter < rgbaValues.Length; counter += 4)
            {
                double t = rgbaValues[counter + 3]/255.0; // transparency of pixel between 0 .. 1 , easier to do math with this
                double rt = 1 - t; // inverted value of transparency
                // C = C * t + W * (1-t) // alpha transparency for your case C-color, W-white (255)
                // same for each color
                rgbaValues[counter] = (byte) (rgbaValues[counter]*t + 255*rt); // R color
                rgbaValues[counter + 1] = (byte)(rgbaValues[counter + 1] * t + 255 * rt); // G color
                rgbaValues[counter + 2] = (byte)(rgbaValues[counter + 2] * t + 255 * rt); // B color
                rgbaValues[counter + 3] = 255; // A = 255 => no transparency 
            }
            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbaValues, 0, ptr, bytes);
            // Unlock the bits.
            bmp.UnlockBits(bmpData);
        }
