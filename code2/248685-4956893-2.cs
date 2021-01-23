	[ValueConversion(typeof(double), typeof(double))]
	public class DivisionConverter : IValueConverter
	{
		double? output; // Where the converted output will be stored if the converter is run.
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (output.HasValue) return output.Value; // If the converter has been called 
			                                          // 'output' will have a value which 
			                                          // then will be returned.
			else
			{
				double input = (double)value;
				double divisor = (double)parameter;
				if (divisor > 0)
				{
					output = input / divisor; // Here the output field is set for the first
					                          // and last time
					return output.Value;
				}
				else return DependencyProperty.UnsetValue;
			}
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
