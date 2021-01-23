   	public class IsAssignableFromConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Type typeParameter = parameter as Type;
			if (typeParameter == null)
				return DependencyProperty.UnsetValue;
			return value != null && typeParameter.IsAssignableFrom(value.GetType());
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
