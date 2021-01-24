	public static void RemoveAll(this DataTable table)
	{
		for (int index = table.Rows.Count - 1; index >= 0; index--)
		{
			table.Rows.RemoveAt(index);
		}
	}
