    public static colorEnum? GetColorFromString(string colorString)
    {
        foreach (colorEnum col in Enum.GetValues(typeof(colorEnum)))
        {
            if (col.ToString().Equals(colorString))
            {
                return col;
            }
        }
        return null;
    }
