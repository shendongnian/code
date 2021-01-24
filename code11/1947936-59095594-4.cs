    public Image CreateWatermarkImage(string text, Font font, Color color, Size size)
    {
        var bm = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
        using (var g = Graphics.FromImage(bm))
        {
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.RotateTransform(45);
            var format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            using (var brush = new SolidBrush(color))
                g.DrawString(text, font, brush, new Rectangle(Point.Empty, size), format);
        }
        return bm;
    }
