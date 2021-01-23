    public static class GrayScaleBrushes
    {
        private static SolidBrush _Pct05;
        public static SolidBrush Pct05
        {
            get
            {
                if (_Pct05 == null)
                {
                    var value = GetRgbValFromPct(5);
                    _Pct05 = new SolidBrush(Color.FromArgb(value, value, value));
                }
                return _Pct05;
            }
        }
        private static int GetRgbValFromPct(int pct)
        {
            // no need to convert to float and back to int again
            return 255 - ((pct * 255) / 100);
        }
    }
