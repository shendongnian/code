    public object Convert(object value, Type targetType, object parameter,System.Globalization.CultureInfo culture)
    {
	   bool boolValue = (bool)value;
       if(boolValue)
        return x;
       else
        return y;
	
    }
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
	    throw new NotImplementedException();
    }
