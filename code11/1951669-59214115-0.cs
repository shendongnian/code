	public static IEnumerable<T> ToList<T>(this DataTable dataTable)
	{
		var properties = typeof(T).GetProperties().Where(x => x.HasSetter).ToList();
		var result = new List<T>();
		// loop on rows
		foreach (DataRow row in dataTable.Rows)
		{
			// create an instance of T generic type.
			var item = Activator.CreateInstance<T>();
			// loop on properties and columns that matches properties
			foreach (var prop in properties)
				foreach (DataColumn column in dataTable.Columns)					
					if (prop.Name == column.ColumnName)
					{
						// Get the value from the datatable cell
						object value = row[column.ColumnName];
						// Set the value into the object
						prop.SetValue(item, value);
						break;
					}
			result.Add(item);
		}
		return result;
	}
