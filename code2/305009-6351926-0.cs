	/// <summary>
	/// Merges the equivalent properties from the source to this object.
	/// </summary>
	/// <typeparam name="T">Any reference type.</typeparam>
	/// <param name="destination">This object, which receives the values.</param>
	/// <param name="source">The source object that the values are taken from.</param>
	public static void MergeFrom<T>(this object destination, T source)
	{
		Type destinationType = destination.GetType();
		PropertyInfo[] propertyInfos = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
		foreach (var propertyInfo in propertyInfos)
		{
			PropertyInfo destinationPropertyInfo = destinationType.GetProperty(propertyInfo.Name, BindingFlags.Public | BindingFlags.Instance);
			if (destinationPropertyInfo != null)
			{
				if (destinationPropertyInfo.CanWrite && propertyInfo.CanRead && (destinationPropertyInfo.PropertyType == propertyInfo.PropertyType))
				{
					object o = propertyInfo.GetValue(source, null);
					destinationPropertyInfo.SetValue(destination, o, null);
				}
			}
		}
	}
