    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        object[] parameters = parameter as object[];
        short index = System.Convert.ToInt16(parameters[0]);
        TextBox sourceTextBox = parameters[1] as TextBox;
        //...
    }
