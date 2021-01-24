    public class ColorResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MarkerColor color = (MarkerColor)value;
            Uri uri;
            switch(color)
            {
                case MarkerColor.Green:
                    uri = new Uri("Resources/green.png");
                    break;
                case MarkerColor.Red:
                    uri = new Uri("Resources/red.png");
                    break;
                //...
                default:
                    uri = new Uri("Resources/default.png");
                    break;
            }
            return new BitmapImage(uri);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
