     private const double StaticGridWidth = 602;
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if ((value != null) && (parameter != null))
        {
            double newValue = (double)value - StaticGridWidth;
            double dparam = double.Parse(parameter.ToString());
            double width = newValue * (dparam/1000);
            return (width > 0) ? width : 0;
        }
        return null;
    }
