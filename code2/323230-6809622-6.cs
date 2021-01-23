	public class BoundsToMarginConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Rect input = (Rect)value;
			return new Thickness()
			{
				Left = -input.Left,
				Right = -input.Right,
				Top = -input.Top,
				Bottom = -input.Bottom,
			};
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
