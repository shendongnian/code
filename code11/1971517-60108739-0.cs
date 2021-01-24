    using System;
    using System.Globalization;
    using Xamarin.Forms;
    
    namespace xxxx
    {
    public class Base64ToImageSource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string base64Image = (string)value;
            return base64Image.GetImageSourceFromBase64String();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    }
