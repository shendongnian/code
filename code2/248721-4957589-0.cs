    public class FontSizeToBrushConverter : IValueConverter {
        public static readonly double Increment = 3;
        public static readonly double MinFontSize = 6;
        public static readonly double MaxFontSize = 32;
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null || value == DependencyProperty.UnsetValue) {
                return DependencyProperty.UnsetValue;
            }
    
            var fontSize = (double) value;
    
            double incrementsCount = MaxFontSize / Increment;
    
            var defaultColor = new SolidColorBrush(Colors.Black);
    
            for (int incrementIndex = 0; incrementIndex < incrementsCount; incrementIndex++) {
                if (fontSize == MinFontSize + Increment * incrementIndex) {
                    switch (incrementIndex) {
                        case 0:
                            return new SolidColorBrush(Colors.Red);
                        case 1:
                            return new SolidColorBrush(Colors.Green);
                        case 2:
                            return new SolidColorBrush(Colors.Blue);
                        default:
                            return defaultColor; // Default color
                    }
                }
            }
    
            return defaultColor; // Default color
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
