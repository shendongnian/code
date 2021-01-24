    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var listItem = value as ListBoxItem;
            if (listItem != null)
            {
                var text = listItem.Content;
                switch (text)
                {
                    case "Green":
                        return new SolidColorBrush(Colors.Green);
                    case "Yellow":
                        return new SolidColorBrush(Colors.Yellow);
                    case "Red":
                        return new SolidColorBrush(Colors.Red);
                }
            }
            return new SolidColorBrush(Colors.Transparent);
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
