        public static IDictionary<string, dynamic> ToDictionary<T>(this T target, bool exceptDefaultValue = false)
			where T : class
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			IDictionary<string, dynamic> dictionary = new Dictionary<string, dynamic>(System.StringComparer.OrdinalIgnoreCase);
			foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(target))
			{
				object value = propertyDescriptor.GetValue(target);
				if (exceptDefaultValue == true)
				{
					if (value == null || value.Equals(propertyDescriptor.PropertyType.DefaultValue()) == true)
					{
						continue;
					}
				}
				dictionary.Add(propertyDescriptor.Name, value);
			}
			return dictionary;
		}
