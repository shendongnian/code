    public class TrimWhiteSpaceValueConverter : IValueConverter
    {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                    if (value == null)
                    {
                            return null;
                    }
                    return value.ToString().Trim();
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                    if (value == null)
                    {
                            return null;
                    }
                    return value.ToString().Trim();
            }
    }
