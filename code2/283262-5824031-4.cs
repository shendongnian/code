    private static void ColorToHSV(Color color, out int hue, out int saturation, out int value)
    {
        int max = Math.Max(color.R, Math.Max(color.G, color.B));
        int min = Math.Min(color.R, Math.Min(color.G, color.B));
        hue = (int)(color.GetHue() * 256f / 360f);
        saturation = (max == 0) ? 0 : (int)(1d - (1d * min / max));
        value = (int)(max / 255d);
    }
