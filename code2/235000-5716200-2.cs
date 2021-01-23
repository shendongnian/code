    public static class GrayScaleBrushes
    {
        public static readonly SolidBrush Pct05;
        static GrayScaleBrushes()
        {
            var value = GetRgbValFromPct(5);
            Pct05 = new SolidBrush(Color.FromArgb(value, value, value));
        }
    }
