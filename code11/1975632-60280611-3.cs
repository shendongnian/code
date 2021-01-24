	private static void directoryChange(object source, System.IO.FileSystemEventArgs e)
	{
		if (e.ChangeType == System.IO.WatcherChangeTypes.Deleted)
		{
			if (fileList.TryGetValue(e.FullPath, out var id))
			{
				Console.WriteLine(id);
			}
			else
			{
				Console.WriteLine($"Path '{e.FullPath}' not present in dictionary?");
			}
		}
	}
				
