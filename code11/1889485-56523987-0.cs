    public class DateToBoolConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2)
                return true;
            IList<DateTime> selectableDates = values[0] as IList<DateTime>;
            if (selectableDates == null)
                return true;
            DateTime currentDate = (DateTime)values[1];
            return selectableDates.Contains(currentDate);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
