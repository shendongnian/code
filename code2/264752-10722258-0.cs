    public sealed class LowerCase : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			var str = value as string;
			return string.IsNullOrEmpty(str) ? string.Empty : str.ToLower();
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {}
	}
