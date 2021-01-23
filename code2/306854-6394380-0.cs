    public Color GetBlendedColor(int percentage)
    {
        if (percentage < 50)
            return Interpolate(Color.Red, Color.Yellow, percentage / 50.0);
        return Interpolate(Color.Yellow, Color.Green, (percentage - 50) / 50.0);
    }
    private Color Interpolate(Color color1, Color color2, double fraction)
    {
        double r = Interpolate(color1.R, color2.R, fraction);
        double g = Interpolate(color1.G, color2.G, fraction);
        double b = Interpolate(color1.B, color2.B, fraction);
        return Color.FromArgb((int)Math.Round(r), (int)Math.Round(g), (int)Math.Round(b));
    }
    private double Interpolate(double d1, double d2, double fraction)
    {
        return d1 + (d1 - d2) * fraction;
    }
