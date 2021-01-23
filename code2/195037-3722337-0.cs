    /// <summary>Blends the specified colors together.</summary>
    /// <param name="color">Color to blend onto the background color.</param>
    /// <param name="backColor">Color to blend the other color onto.</param>
    /// <param name="amount">How much of <paramref name="color"/> to keep,
    /// “on top of” <paramref name="backColor"/>.</param>
    /// <returns>The blended colors.</returns>
    public static Color ColorBlend(Color color, Color backColor, double amount)
    {
        byte r = (byte) ((color.R * amount) + backColor.R * (1 - amount));
        byte g = (byte) ((color.G * amount) + backColor.G * (1 - amount));
        byte b = (byte) ((color.B * amount) + backColor.B * (1 - amount));
        return Color.FromArgb(r, g, b);
    }
