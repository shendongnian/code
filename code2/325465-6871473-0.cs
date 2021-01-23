        public class MyConverter
            : IValueConverter
        {
            public object Convert(
                object value, 
                Type targetType, 
                object parameter, 
                System.Globalization.CultureInfo culture)
            {
                return MyStaticClass.MyStaticMethod(value as MyItem);
            }
            public object ConvertBack(
                object value, 
                Type targetType, 
                object parameter, 
                System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
