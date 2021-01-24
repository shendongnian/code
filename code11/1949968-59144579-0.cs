    public class TypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Type t = value as Type;
    
            if (t == typeof(CmQuote))
                return Visibility.Visible;
            
            return Visibility.Hidden;
        }
    }
