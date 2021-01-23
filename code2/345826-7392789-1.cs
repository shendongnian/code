    public class ConvertMyThingyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var thing= value as Thing;
            if(thing == null)
               return String.Empty;
            return thing.Name ?? thing.Identifier;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
