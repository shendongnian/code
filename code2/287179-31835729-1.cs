    using System;
    using System.Windows.Data;
    namespace BindableParameterExtension
    {
         public class SampleConverter : IValueConverter
         {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value != null && parameter != null)
                {
                    return value.ToString() + ", " + parameter.ToString();
                }
                return null;
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is string && parameter is string)
                {
                    string text1 = value as string;
                    string textParamter = parameter as string;
                    return text1.Replace(textParamter, "");
                }
                return value;
           }
        }
    }    
