        static void GrayscaleToAlpha(Bitmap image) {
            var lockData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            unsafe {
                // Pointer to the current pixel
                uint* pPixel = (uint*)lockData.Scan0;
                // Pointer value at which we terminate the loop (end of pixel data)
                var pLastPixel = pPixel + image.Width * image.Height;
                while (pPixel < pLastPixel) {
                    // Get pixel data
                    uint pixelValue = *pPixel;
                    // Average RGB
                    uint brightness = ((pixelValue & 0xFF) + ((pixelValue >> 8) & 0xFF) + ((pixelValue >> 16) & 0xFF)) / 3;
                    // Use brightness for alpha value, leave R, G, and B zero (black)
                    pixelValue = (255 - brightness) << 24;
                    // Copy back to image
                    *pPixel = pixelValue;
                    // Next pixel
                    pPixel++;
                }
            }
            image.UnlockBits(lockData);
        }
