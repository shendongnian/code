    namespace Solutions.Data.Entities
	{
		using System;
		using System.Collections.Concurrent;
		using System.Reflection;
		using System.Text;
		using System.Linq;
		public static class EntityExtensions
		{
			#region Fields
			private static readonly ConcurrentDictionary<string, PropertyInfo[]> PropertyInfoCache = new ConcurrentDictionary<string, PropertyInfo[]>();
			#endregion
			#region Extension Methods
			/// <summary>
			/// This method will find all the Properties of Entity and display them in formatted way.
			/// </summary>
			/// <typeparam name="T">Entity Type</typeparam>
			/// <param name="value">Entity value</param>
			/// <returns>Formatted string of the Entity Properties</returns>
			public static string PropertiesToString<T>(this T value) where T : IObjectWithChangeTracker
			{
				var type = typeof(T).FullName;
				if (String.IsNullOrEmpty(type)) return String.Empty;
				CachePropertyInfo<T>(type);
				StringBuilder stringBuilder = new StringBuilder();
				foreach (var propertyInfo in PropertyInfoCache[type])
				{
					stringBuilder.AppendLine(String.Format("{0} : {1}", propertyInfo.Name, propertyInfo.GetValue(value, null)));
				}
				return stringBuilder.ToString();
			}
			/// <summary>
			/// Use reflection to find all propertied if key is not found in list.
			/// </summary>
			/// <typeparam name="T">Entity Type</typeparam>
			/// <param name="type">property fullname</param>
			private static void CachePropertyInfo<T>(string type)
			{
				if (!PropertyInfoCache.ContainsKey(type))
				{
					// Get all public properties of T type where T inherits interface IObjectWithChangeTracker
					var properties =
						typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.Name != "ChangeTracker");
					PropertyInfoCache[type] = properties.ToArray();
				}
			}
			#endregion
		}
	}
