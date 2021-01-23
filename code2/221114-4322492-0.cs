	public static class ListExtensions
	{
		public static DataTable ToDataTable<T>(this IList<T> list)
		{
			IList<PropertyInfo> properties = list.GetPropertiesOfObjectInList();
			DataTable resultTable = CreateTable(properties);
			foreach(var item in list)
			{
				var row = CreateRowFromItem<T>(resultTable, item);
				resultTable.Rows.Add(row);
			}
			return resultTable;
		}
		private static DataTable CreateTable(IList<PropertyInfo> properties)
		{
			DataTable resultTable = new DataTable();
			foreach (var property in properties)
			{
				resultTable.Columns.Add(property.Name, property.PropertyType);
			}
			return resultTable;
		}
		public static IList<PropertyInfo> GetPropertiesOfObjectInList<T>(this IList<T> list)
		{
			return typeof(T).GetProperties().ToList();
		}
		private static DataRow CreateRowFromItem<T>(DataTable resultTable, T item)
		{
			var row = resultTable.NewRow();
			var properties = item.GetType().GetProperties().ToList();
			foreach (var property in properties)
			{
				row[property.Name] = property.GetValue(item, null);
			}
			return row;
		}
	}
