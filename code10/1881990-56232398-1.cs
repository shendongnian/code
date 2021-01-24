    class BoolToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "#3EF79B" : "#FFFFFF";
            /*Same as:
            if((bool)value) 
            {
                return "#3EF79B";
            } 
            else 
            {
                return "#FFFFFF";
            }*/
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
