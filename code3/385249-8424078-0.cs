    static Color[] colors = typeof(Color)
        .GetProperties(BindingFlags.Public | BindingFlags.Static)
        .Where(pi => pi.CanRead && pi.PropertyType == typeof(Color))
        .Select(pi => (Color)pi.GetValue(null, null))
        .ToArray();
     static string FindColorName(string _rgb)
    {
        // like "#RRGGBB" or "#AARRGGBB" or "Red" or "red"
        var rgb = ColorTranslator.FromHtml(_rgb);
        foreach (var match in colors.Where(cc => cc.R == rgb.R
                                              && cc.G == rgb.G
                                              && cc.B == rgb.B
                                              && cc.A == rgb.A))
        {
            return match.Name;
        }
        return "#" + rgb.Name;
    }
    // #FFFFFF: White
    // #000000: Black
    // #333333: 333333
    // #FF00FF: Fuchsia (Magenta also matches)
