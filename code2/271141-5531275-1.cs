    using System;
    using System.Globalization;
    using System.Windows.Data;
    
    namespace Expander.Converters
    {
      [ValueConversion(typeof(object), typeof(bool))]
      public sealed class ExpanderConverter : IValueConverter
      {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          bool result = (bool)value;
          return !result;
        }
       
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
          bool result =(bool)value;
          return result;
        }
      }
    }
