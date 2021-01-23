    /// <summary>
    /// Gets the pixel value in bytes. Uses Bitmap GetPixel method.
    /// </summary>
    /// <param name="bmp">Bitmap</param>
    /// <param name="location">Pixel location</param>
    /// <returns>Pixel value</returns>
    public static byte Get8bppImagePixel(Bitmap bmp, Point location)
    {
        Color pixelRGB = bmp.GetPixel(location.X, location.Y);
        int pixel8bpp = Array.IndexOf(bmp.Palette.Entries, pixelRGB);
        return (byte)pixel8bpp;
    }
