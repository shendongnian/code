    var staticProperties = Color.GetType().GetProperties(BindingFlags.Static | BindingFlags.Public);
    var colors = staticProperties.Select(prop => (Color)prop.GetValue(null, null));
    foreach (Color clr in colors)
    {
        // Test the color...
    }
