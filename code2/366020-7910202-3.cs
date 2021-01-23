	public enum MyEnum
	{
		HomeRun, StolenBase, FirstBase
	}
	[ValueConversion(typeof(object), typeof(List<string>))]
	public class MyEnumConverter:IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var names = Enum.GetNames(typeof (MyEnum)).ToArray();
			//Add some code to support the thing you want to do(add blank in front of Capital...)
			return names;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
