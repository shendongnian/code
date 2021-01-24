    public class SeperatorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(string))
                throw new InvalidOperationException("The target must be a string");
            if (value != null)
            {
                var res = string.Join(" ",
                    Enumerable.Range(0, value.ToString().Length / 4).Select(i => value.ToString().Substring(i * 4, 4)));
                return res;
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
