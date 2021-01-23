	public class StringToBitmapImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string uristring = value as string;
			return new BitmapImage(new Uri(uristring, UriKind.RelativeOrAbsolute));
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
