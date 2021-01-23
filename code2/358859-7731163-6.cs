    private int[] screenshot(int x, int y, int width, int height)
    {
        // dispose 'bmp' after use
        using (var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
        {
            // dispose 'g' after use
            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(x, y, 0, 0, bmp.Size);
                var bmd = bmp.LockBits(
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadOnly,
                    bmp.PixelFormat);
                var ptr = bmd.Scan0;
                // as David pointed out, "bytes" might be
                // a bit misleading name for a length of
                // a 32-bit int array (so I've changed it to "len")
                var len = bmd.Stride * bmp.Height / 4;
                var result = new int[len];
                Marshal.Copy(ptr, result, 0, len);
                bmp.UnlockBits(bmd);
                return result;
            }
        }
    }
