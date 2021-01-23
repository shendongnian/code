    var colorType = typeof(System.Drawing.Color);
    var staticProperties = colorType.GetProperties(BindingFlags.Static | BindingFlags.Public);
    var colors = staticProperties.Select(prop => (Color)prop.GetValue(null, null));
    foreach (Color clr in colors)
    {
        // Test the color...
    }
