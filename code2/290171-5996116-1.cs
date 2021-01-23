    public class DistinctConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            var values = value as IEnumerable;
            if (values == null)
                return null;
            return values.Cast<object>().Distinct();
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
