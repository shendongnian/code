    public static string GetColorName(this System.Windows.Media.Color color)
    {
        Type colors = typeof(System.Windows.Media.Colors);
        foreach(var prop in colors.GetProperties())
        {
            if(((System.Windows.Media.Color)prop.GetValue(null, null)) == color)
                return prop.Name;
        }
        throw new Exception("The provided Color is not named.");
    }
