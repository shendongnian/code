    Color Composite(Color color, Color backcolor)
    {
        byte r = (byte)(((255 - color.A) * backcolor.R + color.R * color.A) / 256);
        byte g = (byte)(((255 - color.A) * backcolor.G + color.G * color.A) / 256);
        byte b = (byte)(((255 - color.A) * backcolor.B + color.B * color.A) / 256);
        Color c2 = Color.FromArgb(255, r, g, b);
        return c2;
    }
