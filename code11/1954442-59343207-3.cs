    public class ItemToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            { //Make the required checks here. if you content is comboboxitem or something you have to make the conversion here.
                if (value.ToString().Equals(parameter.ToString()))
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
