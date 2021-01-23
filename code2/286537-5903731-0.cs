    public static string ToString(this double value, int precision)
    {
        string precisionFormat = "".PadRight(precision, '#');
        return String.Format("{0:0." + precisionFormat + "}", value);
    }
