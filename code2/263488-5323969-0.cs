    public sealed class NullToVisibiltyConverter
            : IValueConverter
        {
            #region [ IValueConverter Members ]
    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return value == null ? Visibility.Hidden: Visibility.Visible;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
