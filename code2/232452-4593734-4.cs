	public static class DataTableExtensions
	{
		public static IList<T> ToList<T>(this DataTable table) where T : new()
		{
			IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
			IList<T> result = new List<T>();
			foreach (var row in table.Rows)
			{
				var item = CreateItemFromRow<T>((DataRow)row, properties);
				result.Add(item);
			}
			return result;
		}
		public static IList<T> ToList<T>(this DataTable table, Dictionary<string, string> mappings) where T : new()
		{
			IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
			IList<T> result = new List<T>();
			foreach (var row in table.Rows)
			{
				var item = CreateItemFromRow<T>((DataRow)row, properties, mappings);
				result.Add(item);
			}
			return result;
		}
		private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
		{
			T item = new T();
			foreach (var property in properties)
			{
				property.SetValue(item, row[property.Name], null);
			}
			return item;
		}
		private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties, Dictionary<string, string> mappings) where T : new()
		{
			T item = new T();
			foreach (var property in properties)
			{
                if(mappings.ContainsKey(property.Name))
				    property.SetValue(item, row[mappings[property.Name]], null);
			}
			return item;
		}
	}
