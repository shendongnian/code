    public class TypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {   
            if (t is Type && (Type)t == typeof(CmQuote))
                return Visibility.Visible;
            
            return Visibility.Hidden;
        }
    }
