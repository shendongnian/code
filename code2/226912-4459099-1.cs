       class OverlayVisibilityConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                var isMouseOverOverlay = (bool)values[0];
                var isMouseOverImage = (bool)values[1];
    
                if (isMouseOverImage || isMouseOverOverlay)
                    return Visibility.Visible;
                else
                    return Visibility.Hidden;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
