    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        string entry = (string)value;
        Regex regex = new Regex(@"[0-9a-fA-F]{6}");
        if (!regex.IsMatch(entry)) {
            return Binding.DoNothing;
    
        return entry.Substring(3); 
    }
