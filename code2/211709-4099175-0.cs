    namespace Common.ValueConverters
    {
        using System;
        using System.Windows;
        using System.Windows.Data;
    
        public class VisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is bool?)
                {
                    if (string.IsNullOrEmpty((string)parameter))
                    {
                        return (value as bool?).Value ? Visibility.Visible : Visibility.Collapsed;
                    }
                    else
                    {
                        return (value as bool?).Value ? Visibility.Collapsed : Visibility.Visible;
                    }
                }
                throw new ArgumentException();
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
