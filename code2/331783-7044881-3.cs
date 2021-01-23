<!-- -->
	public class ThresholdConverter : IValueConverter
	{
		public double Threshold { get; set; }
		public object AboveValue { get; set; }
		public object BelowValue { get; set; }
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var converter = new DoubleConverter();
			var input = (double)converter.ConvertFrom(value);
			return input < Threshold ? BelowValue : AboveValue;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
