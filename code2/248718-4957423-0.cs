	public class CountToBrushConverter : IValueConverter
	{
		#region IValueConverter Members
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			const int cap = 32;
			int count = (int)value;
			count -= count % 3;
			double res = count <= cap ? count : cap;
			res /= 32.0;
			Color colour = new Color();
			colour.A = (byte)255;
			colour.B = (byte)(res * 255);
			return new SolidColorBrush(colour);
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
		#endregion
	}
