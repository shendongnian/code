     class ImgToDisplayConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string image = values[0].ToString();
            string resourceName = String.Format("pack://application:,,,/{0}.png", image);
            return new BitmapImage(new Uri(resourceName));
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class ImgPressedToDisplayConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string image = values[0].ToString();
            string resourceName = String.Format("pack://application:,,,/{0}_pressed.png", image);
            return new BitmapImage(new Uri(resourceName));
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
