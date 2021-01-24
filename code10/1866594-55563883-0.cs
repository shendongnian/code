	List<Task<DataTable>> dataTableTasks = new List<Task<DataTable>>();
	foreach (FileInfo flInfo in dir.GetFiles())
	{
		String name = flInfo.Name;
		Console.WriteLine("{0, -30:g} ", name);
		Task<DataTable> mergeTable = processFile(name);
		dataTableTasks.Add(mergeTable);
	}
	await Task.WhenAll(dataTableTasks);
	foreach(Task<DataTable> dataTableTask in dataTableTasks)
	{
		table.Merge(await dataTableTask);
	}
