    static Color[] colors = typeof(Color)
        .GetProperties(BindingFlags.Public | BindingFlags.Static)
        .Where(pi => pi.CanRead && pi.PropertyType == typeof(Color))
        .Select(pi => (Color)pi.GetValue(null, null))
        .ToArray();
    static IEnumerable<string> FindColorNames(string htmlColor)
    {
        // like "#RRGGBB" or "#AARRGGBB" or "Red" or "red"
        var color = ColorTranslator.FromHtml(htmlColor);
        return colors.Where(cc => cc.R == color.R
                               && cc.G == color.G
                               && cc.B == color.B
                               && cc.A == color.A)
                     .Select(cc => cc.Name);
    }
    static string FindColorName(string htmlColor)
    {
        return FindColorNames(htmlColor).FirstOrDefault() ?? htmlColor;
    }
    // #FFFFFF: White
    // #000000: Black
    // #333333: 333333
    // #FF00FF: Fuchsia (Magenta also matches)
