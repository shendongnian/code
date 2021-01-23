         class StringColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string colorString = value.ToString();
            //Color colorF = (Color)ColorConverter.ConvertFromString(color); //displays r,g ,b values
            Color colorF = ColorTranslator.FromHtml(colorString);
            return colorF.Name;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
