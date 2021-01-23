    public static Image GetImageHiQualityResized(this Image image, int width, int height)
    {
        var thumb = new Bitmap(width, height);
        using (var g = Graphics.FromImage(thumb))
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, new Rectangle(0, 0, thumb.Width, thumb.Height));
            return thumb;
        }
    }
