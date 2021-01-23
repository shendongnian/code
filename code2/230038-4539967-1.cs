    class MainWindow {
        ......
        class LevelToMarginConverterClass : IValueConverter {
            const int onelevelmargin = 10;
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                int level = (int)value;
                return new Thickness(level * onelevelmargin,0,0,0);
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                return null;
            }
        }
        public static IValueConverter LevelToMarginConverter = new LevelToMarginConverterClass();
    }
