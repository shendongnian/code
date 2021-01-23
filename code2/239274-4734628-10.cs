    public class NullableBoolToStringConvreter : IValueConverter
	{
		private static readonly string _NullString = "Null";
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value == null ? NullableBoolToStringConvreter._NullString : value.ToString();
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
