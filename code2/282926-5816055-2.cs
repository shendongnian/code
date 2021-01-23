	public class PercentToBrushConverter : IValueConverter
	{
		//http://stackoverflow.com/questions/3722307/is-there-an-easy-way-to-blend-two-system-drawing-color-values/3722337#3722337
		private Color Blend(Color color, Color backColor, double amount)
		{
			byte r = (byte)((color.R * amount) + backColor.R * (1 - amount));
			byte g = (byte)((color.G * amount) + backColor.G * (1 - amount));
			byte b = (byte)((color.B * amount) + backColor.B * (1 - amount));
			return Color.FromRgb(r, g, b);
		}
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			//Assumes the percent property to be an int.
			int input = (int)value;
			Color red = Colors.Red;
			Color yellow = Colors.Yellow;
			Color green = Colors.Green;
			Color color;
			if (input <= 50)
			{
				color = Blend(yellow, red, (double)input/50);
			}
			else
			{
				color = Blend(green, yellow, (double)(input - 50) / 50);
			}
			return new SolidColorBrush(color);
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
