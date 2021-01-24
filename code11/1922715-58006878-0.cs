    public class StateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case State.INACTIVE:
                    return new SolidColorBrush(Utilities.ResourceDictionary["HoverOverColourInactive"]);
                case State.ACTIVE:
                    return new SolidColorBrush(Utilities.ResourceDictionary["HoverOverColourActive"]);
                case State.ACTIVE_GROUP_SET:
                    return new SolidColorBrush(Utilities.ResourceDictionary["BackgroundBasedOnGroupColour"]);
                case State.HIGHLIGHTED:
                    return new SolidColorBrush(Utilities.ResourceDictionary["HighlightThemeColour"]);
                case State.PROCESSING:
                    return new SolidColorBrush(Utilities.ResourceDictionary["ProcessingWellColour"]);
                default:
                    return Brushes.Transparent;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
