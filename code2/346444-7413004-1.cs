    public class EqualityConverter : IMultiValueConverter
    {
        public object Convert(
                object[] values,
                Type targetType,
                object parameter,
                System.Globalization.CultureInfo culture)
        {
            if (values != null)
            {
                for (var i = 1; i < values.Count(); i++)
                {
                    if (values[i] == null || !values[i].Equals(values[i-1]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public object[] ConvertBack(
                 object value,
                 Type[] targetTypes,
                 object parameter,
                 System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
