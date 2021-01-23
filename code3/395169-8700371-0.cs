    public static Bitmap cropRotatedRect(Bitmap source, Rectangle rect, float angle, bool HighQuality)
    {
        Bitmap result = new Bitmap(rect.Width, rect.Height);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.InterpolationMode = HighQuality ? InterpolationMode.HighQualityBicubic : InterpolationMode.Default;
            using (Matrix mat = new Matrix())
            {
                mat.Translate(-rect.Location.X, -rect.Location.Y);
                mat.RotateAt(angle, rect.Location);
                g.Transform = mat;
                g.DrawImage(source, new Point(0, 0));
            }
        }
        return result;
    }
