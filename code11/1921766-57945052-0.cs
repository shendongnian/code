	PopulateList(list, dataTable, (row) =>
		new AircraftModel
		{
			Id = int.Parse(row["id"].ToString()),
			Registration = row["registration"].ToString(),
			Capacity = int.Parse(row["capacity"].ToString()),
			Type = row["type"].ToString()
		}
	);
	public static void PopulateList<T>(List<T> list, DataTable data, Func<DataRow, T> mapFunc)
		where T : new()
	{
		foreach (DataRow row in data.Rows)
		{
			list.Add(mapFunc(row));
		}
	}
