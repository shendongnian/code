    public void ToGrayScale(Bitmap Bmp)
    {
        int rgb;
        Color c;
        for (int y = 0; y < Bmp.Height; y++)
        for (int x = 0; x < Bmp.Width; x++)
        {
            c = Bmp.GetPixel(x, y);
            rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
            Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
        }
    }
