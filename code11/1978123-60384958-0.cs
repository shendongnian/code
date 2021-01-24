	public class BooleanToVisibilityConverter : IValueConverter
	{
		#region IValueConverter Members
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return false;
			var invert = (parameter == null) ? false : Boolean.Parse(parameter.ToString());
			if ((Boolean)value ^ invert)
				return Visibility.Visible;
			else
				return Visibility.Hidden;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
