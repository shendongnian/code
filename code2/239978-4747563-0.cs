        int[] getRGB(Bitmap bmp, int line) {
            var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            try {
                var ptr = (IntPtr)((long)data.Scan0 + data.Stride * (bmp.Height - line - 1));
                var ret = new int[bmp.Width];
                System.Runtime.InteropServices.Marshal.Copy(ptr, ret, 0, ret.Length * 4);
                return ret;
            }
            finally {
                bmp.UnlockBits(data);
            }
        }
