    using System;
    using System.Windows.Data;
    
    namespace BcpBindingExtension
    {
        public class SampleConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value != null && parameter is object[] && ((object[])parameter).Length > 0)
                {
                    return value.ToString() + ", " + ((object[])parameter)[0].ToString();
                }
                return null;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is string && parameter is object[] && ((object[])parameter).Length > 0)
                {
                    string text1 = value as string;
                    string textParamter = ((object[])parameter)[0] as string;
    
                    return text1.Replace(textParamter, "");
    
                }
    
                return value;
            }
        }
    }
