    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is Dictionary<string, object>)
                {
                    var input = (Dictionary<string, object>)value;
                    if (input.ContainsKey(_key))
                        return input[_key];
                }   
        
