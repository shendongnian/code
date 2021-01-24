     using System;
     using System.Collections.Generic;
     using System.Text;
     using System.Globalization;
     using System.IO;
     using Xamarin.Forms;
     namespace ImageBa54C
     {
      public class Base64ToImageSource : IValueConverter
      {
        ImageSource image;
        public object Convert(object value, Type targetType, object parameter, CultureInfo 
       culture)
        {
            byte[] bytes = System.Convert.FromBase64String(value.ToString());
            image = ImageSource.FromStream(() => new MemoryStream(bytes));
            return image;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
        }
     }
