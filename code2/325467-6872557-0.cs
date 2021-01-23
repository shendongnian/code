	//<Property declarations>
	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	{
		bool staticCall = TargetObject == null;
		var types = new Type[] { value.GetType() };
		var args = new object[] { value };
		MethodInfo method;
		if (staticCall)
		{
			method = TargetType.GetMethod(MethodName, types);
		}
		else
		{
			method = TargetObject.GetType().GetMethod(MethodName, types);
		}
		var score = method.Invoke(TargetObject, args);
		//Convert score
	}
