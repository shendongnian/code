		public static bool HasProperty(this object obj, params string[] properties)
		{
			return HasProperty(obj.GetType(), properties);
		}
		public static bool HasProperty(this Type type, params string[] properties)
		{
			if (properties.Length == 0) // if done properly, shouldn't need this
				return false;
			var propertyInfo = type.GetProperty(properties[0]);
			if (propertyInfo != null)
			{
				if (properties.Length == 1)
					return true;
				else // need to check the next level...
				{
					Type innerType = propertyInfo.PropertyType.GetGenericArguments().FirstOrDefault();
					if (innerType != null)
						return HasProperty(innerType, properties.Skip(1).ToArray());
					else
						return false;
				}
			}
			else
				return false;
		}
		public static void Testing()
		{
			MasterInfo masterInfo = new MasterInfo();
			Console.WriteLine(HasProperty(masterInfo, "Id")); // true
			Console.WriteLine(HasProperty(masterInfo, "Contacts", "Name")); // true
			Console.WriteLine(HasProperty(masterInfo, "Contacts", "Address")); // false
		}
