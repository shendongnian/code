	foreach (var myObject in objects)
	{
		var row = table.NewRow();
		// TODO implement some caching: dont call GetProperties(), GetMethod(), for every object
		var type = myObject.GetType();
		var properties = type.GetProperties();
		foreach (var info in properties)
		{
			try
			{
				// call the IsNullMethod for the property, eg "IsPROP_NUMERIC_ANull"
				var isNullMethodName = $"Is{info.Name}Null";
				var isNullMethod = type.GetMethod(isNullMethodName, BindingFlags.Instance | BindingFlags.Public);
				if (isNullMethod != null)
				{
					var fldIsNull = (bool)isNullMethod.Invoke(myObject, new object[] { });
					if (!fldIsNull)
						row[info.Name] = info.GetValue(myObject, null);
				} else
				{
					// isNullMethod doesn't exist
					row[info.Name] = info.GetValue(myObject, null);
				}
			}
			catch
			{
				// do nothing
			}
		}
		table.Rows.Add(row);
	}
