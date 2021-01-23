    public Bitmap GrayScale(Bitmap Bmp)
    {
        int rgb;
        Color c;
        for (int y = 0; y < Bmp.Height; y++)
        for (int x = 0; x < Bmp.Width; x++)
        {
            c = Bmp.GetPixel(x, y);
            rgb = (int)((c.R + c.G + c.B) / 3);
            Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
        }
        return Bmp;
    }
