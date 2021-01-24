    public class ResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string resourceName = value as string;
            if (!string.IsNullOrEmpty(resourceName)) //look up the resource here:
                return Resource1.ResourceManager.GetString(resourceName);
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
