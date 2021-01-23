	private DataTable CreateDataTableFromObjects<T>(List<T> items, string name = null)
	{
		var myType = typeof(T);
		if (name == null)
		{
			name = myType.Name;
		}
		DataTable dt = new DataTable(name);
		foreach (PropertyInfo info in myType.GetProperties())
		{
			dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
		}
		foreach (var item in items)
		{
    		DataRow dr = dt.NewRow();
			foreach (PropertyInfo info in myType.GetProperties())
			{
				dr[info.Name] = info.GetValue(item);
			}
			dt.Rows.Add(dr);
		}
		return dt;
	}
