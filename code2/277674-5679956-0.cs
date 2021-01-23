	public class SelectConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (!(value is IEnumerable)) throw new Exception("Input is not enumerable");
			IEnumerable input = ((IEnumerable)value);
			var propertyName = parameter as string;
			PropertyInfo propInfo = null;
			List<object> list = new List<object>();
			foreach (var item in input)
			{
				if (propInfo == null)
				{
					propInfo = item.GetType().GetProperty(propertyName);
					if (propInfo == null) throw new Exception(String.Format("Property \"{0}\" not found on enumerable element type", propertyName));
				}
				list.Add(propInfo.GetValue(item, null));
			}
			return list;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
