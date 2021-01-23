        public class ReadConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                bool ReadState =(bool)value;
                    if (ReadState == false)
                        return new SolidColorBrush(Colors.Black);// new SolidColorBrush((Color)Application.Current.Resources["PhoneAccentColor"]);
                    else
                        return new SolidColorBrush(Colors.Black);
                
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
