    public static class ColorExtensions
    {
        public static string ToRgb(this int argb)
        {
            var r = ((argb >> 16) & 0xff);
            var g = ((argb >> 8) & 0xff);
            var b = (argb & 0xff);
            return string.Format("{0:X2}{1:X2}{2:X2}", r, g, b);
        }
    }
