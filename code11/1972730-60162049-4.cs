	public class BindingConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (value as FrameworkElement)?.GetBindingExpression(parameter as DependencyProperty)?.ResolvedSourcePropertyName;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
