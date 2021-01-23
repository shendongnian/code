    public class EnumItemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!value.GetType().IsEnum)
                return false;
            var enumName = value.GetType();
            var obj = Enum.Parse(enumName, value.ToString());
            return System.Convert.ToInt32(obj);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.ToObject(targetType, System.Convert.ToInt32(value));
        }
    }
