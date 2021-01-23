    public static Bitmap GetHighPerformanceBitmap(Image original)
    {
        Bitmap bitmap;
        bitmap = new Bitmap(original.Width, original.Height, PixelFormat.Format32bppPArgb);
        bitmap.SetResolution(original.HorizontalResolution, original.VerticalResolution);
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            g.DrawImage(original, new Rectangle(new Point(0, 0), bitmap.Size), new Rectangle(new Point(0, 0), bitmap.Size), GraphicsUnit.Pixel);
        }
        return bitmap;
    }
