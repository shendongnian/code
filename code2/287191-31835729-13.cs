    using System;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace WpfMarkupExtension
    {
        public class SampleConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value != null && parameter is TextBox)
                {
                    return value.ToString() + ", " + ((TextBox)parameter).Text;
                }
                return null;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is string && parameter is TextBox)
                {
                    string text1 = value as string;
                    string textParamter = ((TextBox)parameter).Text;
    
                    return text1.Replace(textParamter, "");
    
                }
    
                return value;
            }
        }
    }
