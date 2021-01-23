    static Bitmap LoadImage(Stream stream)
    {
        Bitmap retval = null;
        using (Bitmap b = new Bitmap(stream))
        {
            retval = new Bitmap(b.Width, b.Height, b.PixelFormat);
            using (Graphics g = Graphics.FromImage(retval))
            {
                g.DrawImage(b, Point.Empty);
                g.Flush();
            }
        }
        return retval;
    }
