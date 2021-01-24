    using System;
    using System.Globalization;
    using System.Windows.Data;
    
    namespace WpfApp1
    {
        internal class ValidNamesConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string valAsString = value.ToString();
    
                if (valAsString == "Adam" || valAsString == "Eve")
                    return value;
    
                return string.Empty;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
