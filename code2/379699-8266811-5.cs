    public class PathConverter: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//Console.WriteLine("Value:" + value);
				return "Data/Icons/" + value + ".png";
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return "";
		}
	}
