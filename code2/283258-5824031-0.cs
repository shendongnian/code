    private static Color[] GetImageData(Image image)
    {
        using (var b = new Bitmap(image))
        {
            var bd = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            byte[] arr = new byte[bd.Width * bd.Height * 3];
            Color[] colors = new Color[bd.Width * bd.Height];
            Marshal.Copy(bd.Scan0, arr, 0, arr.Length);
            b.UnlockBits(bd);
            for (int i = 0; i < colors.Length; i++)
            {
                var start = i*3;
                colors[i] = Color.FromArgb(arr[start], arr[start + 1], arr[start + 2]);
            }
            return colors;
        }
    }
