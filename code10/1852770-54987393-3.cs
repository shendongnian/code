    internal const string Null = "";
    public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return Null;
        return value.ToString();
    }
    public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
    {
        string s = value?.ToString();
        if (s == Null)
            return null;
        return Enum.Parse(typeof(T), s);
    }
