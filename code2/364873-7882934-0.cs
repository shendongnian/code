    [ValueConversion(typeof(string), typeof(object))]
    public class ResourceKeyConverter : IValueConverter
    {
        public ResourceKeyConverter()
        {
            Resources = new ResourceDictionary();
        }
     
        public ResourceDictionary Resources { get; private set; }
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            return Resources[(string)value];
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
