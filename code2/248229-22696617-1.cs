	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	namespace WebOpsApi.Shared.Helpers
	{
		public static class MappingExtension
		{
			public static T ToObject<T>(this IDictionary<string, object> source)
				where T : class, new()
			{
				var someObject = new T();
				var someObjectType = someObject.GetType();
				foreach (var item in source)
				{
					var key = char.ToUpper(item.Key[0]) + item.Key.Substring(1);
					var targetProperty = someObjectType.GetProperty(key);
					
					if (targetProperty.PropertyType == typeof (string))
					{
						targetProperty.SetValue(someObject, item.Value);
					}
					else
					{
						var parseMethod = targetProperty.PropertyType.GetMethod("TryParse",
							BindingFlags.Public | BindingFlags.Static, null,
							new[] {typeof (string), targetProperty.PropertyType.MakeByRefType()}, null);
						
						if (parseMethod != null)
						{
							var parameters = new[] { item.Value, null };
							var success = (bool)parseMethod.Invoke(null, parameters);
							if (success)
							{
								targetProperty.SetValue(someObject, parameters[1]);
							}
						}
					}
				}
				return someObject;
			}
			public static IDictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
			{
				return source.GetType().GetProperties(bindingAttr).ToDictionary
				(
					propInfo => propInfo.Name,
					propInfo => propInfo.GetValue(source, null)
				);
			}
		}
	}
