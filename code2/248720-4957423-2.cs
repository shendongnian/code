	public class CountToBrushConverter : IValueConverter
	{
		#region IValueConverter Members
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			const int cap = 32;
			int count = (int)value;
			count -= count % 3; // Modulo division to make sure
			                    // that the value only changes
			                    // every 3 steps
			double res = count <= cap ? count : cap; // Check if maximum
			                                         // has been reached
			res /= cap; // Normalize value to be between 0 and 1
			Color colour = new Color();
			colour.ScA = 1; // Set the alpha to full visibility
			colour.ScB = (float)res; // Set the blue channel to our value
			return new SolidColorBrush(colour);
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
		#endregion
	}
