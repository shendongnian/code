	var list2 = Map(dataTable, (row) =>
		new AircraftModel
		{
			Id = int.Parse(row["id"].ToString()),
			Registration = row["registration"].ToString(),
			Capacity = int.Parse(row["capacity"].ToString()),
			Type = row["type"].ToString()
		}
	);
	public static IEnumerable<T> Map<T>(DataTable data, Func<DataRow, T> mapFunc)
		where T : new()
	{
		foreach (DataRow row in data.Rows)
		{
			yield return mapFunc(row);
		}
	}
