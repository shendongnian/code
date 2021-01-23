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
                var bytes = bmd.Stride * bmp.Height / 4;
                var result = new int[bytes];
                Marshal.Copy(ptr, result, 0, bytes);
                bmp.UnlockBits(bmd);
                return result;
            }
        }
    }
