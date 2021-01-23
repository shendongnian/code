    	public static object GetValue(object o, string propertyName)
		{
			Type type = o.GetType();
			PropertyInfo propertyInfo = type.GetProperties(BindingFlags.Public | BindingFlags.Instance ).Where(x => x.Name == propertyName).FirstOrDefault();
			if(propertyInfo!=null)
			{
				return propertyInfo.GetValue(o, BindingFlags.Instance, null, null, null);
			}
			else
			{
				return null; // or throw exception 
			}
		}
