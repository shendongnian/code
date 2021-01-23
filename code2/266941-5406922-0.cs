    public static class Extensions
    {
        public static Tuple<float, float, float> GetPixelHSB(this Bitmap bitmap, int x, int y)
        {
            Color c = bitmap.GetPixel(x, y);
            float h, s, b;
            h = c.GetHue();
            s = c.GetSaturation();
            b = c.GetBrightness();
            return Tuple.Create<float, float, float>(h, s, b);
        }
        public static void SetPixelHSB(this Bitmap bitmap, int x, int y, Tuple<float, float, float> hsb)
        {
            bitmap.SetPixelHSB(x, y, hsb.Item1, hsb.Item2, hsb.Item3);
        }
        public static void SetPixelHSB(this Bitmap bitmap, int x, int y, float h, float s, float b)
        {
            Color c = ColorFromHSBFunction(h, s, b);
            bitmap.SetPixel(x, y, c);
        }
    }
