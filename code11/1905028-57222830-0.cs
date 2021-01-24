    public static void TruncateToMaxLength<TClass>(this TClass inClass)
	{
		foreach (PropertyInfo classProp in inClass.GetType().GetProperties()) // This Line
		{
			var maxLengthAttribute = classProp.GetCustomAttribute<MaxLengthAttribute>();
			if (null != maxLengthAttribute)
			{
				int maxLength = maxLengthAttribute.MaximumLength;
				var inClassProp = classProp.GetValue(inClass);
				if (null != inClassProp)
				{
					var strProp = inClassProp.ToString();
					classProp.SetValue(inClass,
						strProp.Length > maxLength ? strProp.Substring(0, maxLength) : strProp);
				}
			}
		}
	}
