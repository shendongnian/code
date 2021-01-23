        public class UserTemplateSelector : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                int userCount = (int) value;
                if (userCount == 1)
                {
                    return (DataTemplate) Application.Current.Resources["SingleUserTemplate"]; //SingleUserTemplate should be created e.g. in App.xaml
                }
    
                return (DataTemplate)Application.Current.Resources["MultipleUserTemplate"]; //MultipleUserTemplate should be created e.g. in App.xaml
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
