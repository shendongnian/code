    public class TitleMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string fileName = values[0].ToString();
            bool modified = (bool)values[1];
            if (fileName == null)
                return "Foo";
            return fileName + (modified ? " *" : "");
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
