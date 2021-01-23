    public static Color GetColorFromYear(int year)
    {
        var colors = new Color[] { Color.Red, Color.Yellow, Color.Green, ... };
        return colors[year % colors.Length];
    }
