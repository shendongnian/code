    class BoolToBrush : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value != null)
                {
                    if ((bool)value == false)
                    {
                        return new SolidColorBrush(Colors.Orange);
                    }
                    else
                    {
                        return new SolidColorBrush(Colors.Black);
                    }
                }
                else
                {
                    return new SolidColorBrush(Colors.Red);
                }
            }
