    public class LineBreakCorrectionConverter : IValueConverter
    {
        private const string CR = "\r";
        private const string CRLF = "\r\n";
   
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string text = value as string;
            if (text == null)
                return null;
            return text.Replace(CRLF, CR);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string text = value as string;
            if (text == null)
                return null;
            return text.Replace(CR, CRLF);
        }
    }
