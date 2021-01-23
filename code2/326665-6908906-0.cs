    public class MyConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
             // Do stuff with parameter, for example:-
             int month = Convert.ChangeType(parameter, typeof(int), culture);
             return cultrue.DateTimeFormat.GetAbbreviatedMonthName(month + 1);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
