	public sealed class StaticMethodToValueConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				var methodPath = (parameter as string).Split('.');
				if (methodPath.Length < 2) return DependencyProperty.UnsetValue;
				string methodName = methodPath.Last();
				var fullClassPath = new List<string>(methodPath);
				fullClassPath.RemoveAt(methodPath.Length - 1);
				Type targetClass = Assembly.GetExecutingAssembly().GetType(String.Join(".", fullClassPath));
				var methodInfo = targetClass.GetMethod(methodName, new Type[0]);
				if (methodInfo == null)
					return value;
				return methodInfo.Invoke(null, null);
			}
			catch (Exception)
			{
				return DependencyProperty.UnsetValue;
			}
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException("MethodToValueConverter can only be used for one way conversion.");
		}
	}
