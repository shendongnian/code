    var colorProperties = Colors.GetType().GetProperties(BindingFlags.Static | BindingFlags.Public);
    var colors = colorProperties.Select(prop => (Color)prop.GetValue(null, null));
    foreach(Color myColor in colors)
    {
        // ....
