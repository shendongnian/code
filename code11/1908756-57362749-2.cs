    public class EnumerationToDescriptionConverter : IValueConverter
    {
	    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	    {
		    var casted = value as Enum;
		    return casted?.GetDescription();
	    }
	    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	    {
			//we have no need to get from visual descirption to the enumeration at this time.
		    throw new NotImplementedException();
	    }
    }
