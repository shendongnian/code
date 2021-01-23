    public class ButtonColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int current = (int)values[0];
            int button = (int)values[1];
    
            return button == current
                ? Brushes.NavajoWhite
                : Brushes.XXX;  //set the desired color
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
