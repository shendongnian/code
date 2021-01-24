    public string alGulum(object data)
	{
		Type myType = data.GetType();
		IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
		string json = "{";
		foreach (PropertyInfo prop in props)
		{
			object propValue = prop.GetValue(data, null);
			json += "\"" + prop.Name + "\"";
			if (prop.PropertyType == typeof(string))
			{
				json +=":\"" + propValue + "\",";
			}
			else
			{
				json +=":" + propValue + ",";
			}
		}
		json += "}";
		return json;
	}
