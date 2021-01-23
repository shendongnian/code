    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        object[] parameters = parameter as object[];
        short index = (short)parameters[0];
        object source = (parameters[1] as TextBox).DataContext;
        //...
    }
