    MyType Default { get; set; }
	public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	{
		// compare values, return value if equal or default
	}
	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
	{
		return Enumerable.Repeat(value, targetTypes.Count).ToArray();
	}
