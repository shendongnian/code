    public static bool IsImageTransparent(string fullName)
    {
        using (Bitmap bitmap = Bitmap.FromFile(fullName) as Bitmap)
        {
            bool isTransparent;
            // Not sure if the following enumeration is correct. Maybe some formats do not actually allow transparency.
            PixelFormat[] formatsWithAlpha = new[] { PixelFormat.Indexed, PixelFormat.Gdi, PixelFormat.Alpha, PixelFormat.PAlpha, PixelFormat.Canonical, PixelFormat.Format1bppIndexed, PixelFormat.Format4bppIndexed, PixelFormat.Format8bppIndexed, PixelFormat.Format16bppArgb1555, PixelFormat.Format32bppArgb, PixelFormat.Format32bppPArgb, PixelFormat.Format64bppArgb, PixelFormat.Format64bppPArgb };
            if (formatsWithAlpha.Contains(bitmap.PixelFormat))
            {
                // There might be transparency.
                BitmapData binaryImage = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.ReadOnly, PixelFormat.Format64bppArgb);
                unsafe
                {
                    byte* pointerToImageData = (byte*)binaryImage.Scan0;
                    int numberOfPixels = bitmap.Width * bitmap.Height;
                    isTransparent = false;
                    // 8 bytes = 64 bits, since our image is 64bppArgb.
                    for (int i = 0; i < numberOfPixels * 8; i += 8)
                    {
                        // Check the last two bytes (transparency channel). First six bytes are for R, G and B channels. (0, 32) means 100% opacity.
                        if (pointerToImageData[i + 6] != 0 || pointerToImageData[i + 7] != 32)
                        {
                            isTransparent = true;
                            break;
                        }
                    }
                }
                bitmap.UnlockBits(binaryImage);
            }
            else
            {
                // No transparency available for this image.
                isTransparent = false;
            }
            return isTransparent;
        }
    }
