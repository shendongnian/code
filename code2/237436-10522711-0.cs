void BlockingFileCopySync(FileInfo original, FileInfo copyPath)
{
	bool ready = false;
	
	FileSystemWatcher watcher = new FileSystemWatcher();
	watcher.NotifyFilter = NotifyFilters.LastWrite;
	watcher.Path = copyPath.Directory.FullName;
	watcher.Filter = "*" + copyPath.Extension;
	watcher.EnableRaisingEvents = true;
	bool fileReady = false;
	bool firsttime = true;
	DateTime previousLastWriteTime = new DateTime();
	// modify this as you think you need to...
	int waitTimeMs = 100;
	
	watcher.Changed += (sender, e) =>
	{
		// Get the time the file was modified
		// Check it again in 100 ms
		// When it has gone a while without modification, it's done.
		while (!fileReady)
		{
			// We need to initialize for the "first time", 
			// ie. when the file was just created.
			// (Really, this could probably be initialized off the
			// time of the copy now that I'm thinking of it.)
			if (firsttime)
			{
				previousLastWriteTime = System.IO.File.GetLastWriteTime(copyPath.FullName);
				firsttime = false;
				System.Threading.Thread.Sleep(waitTimeMs);
				continue;
			}
			DateTime currentLastWriteTime = System.IO.File.GetLastWriteTime(copyPath.FullName);
			bool fileModified = (currentLastWriteTime != previousLastWriteTime);
			if (fileModified)
			{
				previousLastWriteTime = currentLastWriteTime;
				System.Threading.Thread.Sleep(waitTimeMs);
				continue;
			}
			else
			{
				fileReady = true;
				break;
			}
		}
	};
	System.IO.File.Copy(original.FullName, copyPath.FullName, true);
	// This guy here chills out until the filesystemwatcher 
	// tells him the file isn't being writen to anymore.
	while (!fileReady)
	{
		System.Threading.Thread.Sleep(waitTimeMs);
	}
}
