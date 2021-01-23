    public class ColorConverter : IValueConverter
	{
		#region Implementation of IValueConverter
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				var val = System.Convert.ToInt32(value.ToString());
				var param = System.Convert.ToInt32(parameter.ToString());
				return val >= param ? Brushes.Green : Brushes.White;
				
			}
			catch
			{
				return Brushes.White;
			}
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
