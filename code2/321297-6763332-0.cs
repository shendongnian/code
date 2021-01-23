	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	{
		var c = (Color)value;
		var l = 0.2126 * c.ScR + 0.7152 * c.ScG + 0.0722 * c.ScB;
		if (l < 0.5)
		{
			return Brushes.White;
		}
		else
		{
			return Brushes.Black;
		}
	}
