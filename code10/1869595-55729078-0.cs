    public static List<T> toList<T>(this DataTable table) where T : new()
	{
		try
		{
			var list = table.toList(typeof(T));
			var newLIst = list.Cast<T>().ToList();
			return newLIst;
		}
		catch 
		{
			return null;
		}
	}
	public static List<object> toList(this DataTable table, Type type)
	{
		try
		{
			List<object> list = new List<object>();
			foreach (var row in table.AsEnumerable())
			{
				var obj = row.toObject(type);
				list.Add(obj);
			}
			return list;
		}
		catch 
		{
			return null;
		}
	}
	public static object toObject(this DataRow row, Type type, string sourcePropName = "")
	{
		try
		{
			var obj = Activator.CreateInstance(type);
			var props = type.GetProperties();
			foreach (var prop in props)
			{
				PropertyInfo propertyInfo = type.GetProperty(prop.Name);
				Type targetType = propertyInfo.PropertyType;
				string propName = prop.Name;
				if (!string.IsNullOrWhiteSpace(sourcePropName))
				{
					propName = sourcePropName + "__" + propName;
					if (!row.Table.Columns.Contains(propName))
					{
						propName = prop.Name;
					}
				}
				if (row.Table.Columns.Contains(propName))
				{
					try
					{
						object value = row[propName];
						if (value != null)
						{
							if (value.GetType() == typeof(string))
							{
								if (string.IsNullOrWhiteSpace(value.ToString()))
								{
									value = null;
								}
							}
							targetType = targetType.handleNullableType();
							value = Convert.ChangeType(value, targetType);
							propertyInfo.SetValue(obj, value);
						}
					}
					catch
					{
						continue;
					}
				}
				else
				if (targetType.IsClass && targetType != typeof(string))
				{
					if (targetType.IsGenericList())
					{
						Type ltype = targetType.GetProperty("Item").PropertyType;
						object value = row.toObject(ltype, propName);
						if (value == null)
						{
							continue;
						}
						var valList = new List<object> { value }.ConvertList(targetType);
						try
						{
							propertyInfo.SetValue(obj, valList);
						}
						catch (Exception ex)
						{
							log.Error(ex);
						}
					}
					else
					{
						object value = row.toObject(targetType, propName);
						propertyInfo.SetValue(obj, value);
					}
				}
			}
			return obj;
		}
		catch 
		{
			return null;
		}
	}
	public static object ConvertList(this List<object> value, Type type)
	{
		IList list = (IList)Activator.CreateInstance(type);
		foreach (var item in value)
		{
			list.Add(item);
		}
		return list;
	}
