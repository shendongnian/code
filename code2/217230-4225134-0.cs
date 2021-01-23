    class ImageDownloader : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string url =(string)value;
            return getImage(url);
        }
        private object getImage(string imagefile)
        {
           /// IMPLEMENT FUNCTION TO DOWNLOAD IMAGE FROM SERVER HERE
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
</pre>
