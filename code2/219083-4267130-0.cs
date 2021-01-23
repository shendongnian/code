    class ColorToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            String colorName = (String)value;
            switch (colorName.ToLower())
            {
                case "red":
                    return new BitmapImage(new Uri("..."));
                default:
                    return new BitmapImage(new Uri("..."));
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
