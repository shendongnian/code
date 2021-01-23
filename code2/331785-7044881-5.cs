<!-- -->
	public class ThresholdConverter : IValueConverter
	{
		public double Threshold { get; set; }
		public object AboveValue { get; set; }
		public object BelowValue { get; set; }
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double input;
			if (value is double)
			{
				input = (double)value;
			}
			else
			{
				var converter = new DoubleConverter();
				input = (double)converter.ConvertFrom(value);
			}
			return input < Threshold ? BelowValue : AboveValue;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
