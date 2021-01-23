    public Bitmap GrayScaleFilter(Bitmap image)
    {
        Bitmap grayScale = new Bitmap(image.Width, image.Height);
        for (Int32 y = 0; y < grayScale.Height; y++)
            for (Int32 x = 0; x < grayScale.Width; x++)
            {
                Color c = image.GetPixel(x, y);
                Int32 gs = (Int32)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                grayScale.SetPixel(x, y, Color.FromArgb(gs, gs, gs));
            }
        return grayScale;
    }
