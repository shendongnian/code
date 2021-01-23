	/// <summary>
	/// 	Converts an object to the specified target type or returns the default value.
	/// </summary>
	/// <typeparam name = "T"></typeparam>
	/// <param name = "value">The value.</param>
	/// <param name = "defaultValue">The default value.</param>
	/// <returns>The target type</returns>
	public static T ConvertTo<T>(this object value, T defaultValue)
	{
		if (value != null)
		{
			try
			{
				var targetType = typeof(T);
				var valueType = value.GetType();
				if (valueType == targetType)
					return (T)value;
				var converter = TypeDescriptor.GetConverter(value);
				if (converter != null)
				{
					if (converter.CanConvertTo(targetType))
						return (T)converter.ConvertTo(value, targetType);
				}
				converter = TypeDescriptor.GetConverter(targetType);
				if (converter != null)
				{
					if (converter.CanConvertFrom(valueType))
					{
						return (T)converter.ConvertFrom(value);
					}
				}
			}
			catch (Exception e)
			{
				return defaultValue;
			}
		}
		return defaultValue;
	}
