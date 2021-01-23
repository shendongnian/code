    static Dictionary<int, string[]> colors = static Color[] colors = typeof(Color)
        .GetProperties(BindingFlags.Public | BindingFlags.Static)
        .Where(pi => pi.CanRead && pi.PropertyType == typeof(Color))
        .Select(pi => (Color)pi.GetValue(null, null))
        .GroupBy(cc => cc.ToArgb())
        .ToDictionary(gg => gg.Key, gg.Select(cc => cc.Name).ToArray());
    static IEnumerable<string> FindColorNames(string htmlColor)
    {
        var color = ColorTranslator.FromHtml(htmlColor);
        string[] names;
        if (!colors.TryGetValue(color.ToArgb(), out names))
        {
            return Enumerable.Empty<string>();
        }
        return names;
    }
    static string FindColorName(string htmlColor)
    {
        return FindColorNames.FirstOrDefault() ?? htmlColor;
    }
