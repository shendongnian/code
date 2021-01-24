    class StringToByteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is String)
            {
                string valueTyped = (String)value;
                if (String.IsNullOrEmpty(valueTyped) == false && valueTyped.Length <= 2)
                    return System.Convert.ToByte(valueTyped, 16);
            }
            return new byte();
        }
    }
