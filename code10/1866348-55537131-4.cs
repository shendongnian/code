    public class StringToBooleanConverter: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value.ToString().Equals("y");
		}
        // This is not really needed because you're using one way binding but it's here for completion
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if(value is bool)
			{
				return value ? "y" : "n";
			}
		}
	}
