	string path = FindAppPath("Beyond Compare"); 
	if (path == null)
	{
		Console.WriteLine("Failed to find program path.");
		return;
	}
	Process beyondCompare = new Process()
	{
		StartInfo = new ProcessStartInfo()
		{
			FileName = path + "BeyondCompare.exe",
			Arguments = string.Empty // You may need to specify args.
		}
	};
	beyondCompare.Start();
