	public class SingleStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return String.IsNullOrEmpty(value?.ToString()) ? "[Discard style]" : value;
			
		}
	}
