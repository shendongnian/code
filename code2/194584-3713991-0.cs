    public static int ToInt32(string value)
    {
        if (value == null)
        {
            return 0;
        }
        return int.Parse(value, CultureInfo.CurrentCulture);
    }
    
    public static int Parse(string s)
    {
        return Number.ParseInt32(s, NumberStyles.Integer, NumberFormatInfo.CurrentInfo);
    }
