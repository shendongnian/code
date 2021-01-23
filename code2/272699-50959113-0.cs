		// Copies the custom properties on the control. To use it, cast your object to it. 
		public static object CopyUserControl(object obj, object obj2)
		{
			Type type = obj.GetType();
			PropertyInfo[] properties = type.GetProperties();
			Type type2 = obj2.GetType();
			PropertyInfo[] properties2 = type.GetProperties();
			foreach (PropertyInfo property in properties)
			{
				foreach (PropertyInfo property2 in properties2)
				{
					// Match the loops and ensure it's not a non-custom property 
					if (property.Name == property2.Name && property.SetMethod != null && !property.SetMethod.IsSecuritySafeCritical)
						property2.SetValue(obj2, property.GetValue(obj, null));
				}
			}
			return obj2;
		}
