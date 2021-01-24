public class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is decimal)
                return value.ToString();
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (decimal.TryParse(value as string, out var dec))
                return dec;
            return value;
        }
    }
**Usage**
<Entry Text="{Binding Weight, Converter={StaticResource DecimalConverter}}" />
that All :)
