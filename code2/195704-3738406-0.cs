    public class ImageLoadingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is string)) return null;
            var rm = new ResourceManager("Project.Properties.Resources", GetType().Assembly);
            using (var stream = rm.GetStream((string)value))
            {
                return BitmapFrame.Create(stream);
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
