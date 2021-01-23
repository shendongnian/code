    public class GroupNameToStringConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var grouping = (IGrouping<string, [YOUR CLASS NAME]>) value;
    
                return grouping.Key;
            }
    
        }
