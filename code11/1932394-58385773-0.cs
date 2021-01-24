public static async Task Main(string[] args)
{
	string dir = @"C:\tmp";
	var watcher = new System.IO.FileSystemWatcher();
	watcher.Path = dir;
	//watcher.NotifyFilter = ; //Add filters if desired
	watcher.Filter = "*.*";
	watcher.Changed += 
	   (source, e) =>  Console.WriteLine($"{DateTime.UtcNow}: {e.ChangeType} {e.FullPath}");
	watcher.Created +=
	  (source, e) => Console.WriteLine($"{DateTime.UtcNow}: {e.ChangeType} {e.FullPath}");
	watcher.EnableRaisingEvents = true;
	Console.ReadLine();
}
Example output 
15/10/2019 00:49:24: Created C:\tmp\New Text Document.txt
15/10/2019 00:49:30: Changed C:\tmp\New Text Document.txt
15/10/2019 00:49:30: Changed C:\tmp\New Text Document.txt
----
# Directory.GetLastWriteTimeUtc
If you just want to detect if there are new files in the top directory (no in subdirectories) you can use `Directory.GetLastWriteTimeUtc(String)`.
Please note the note though:
> This method may return an inaccurate value, because it uses native functions whose values may not be continuously updated by the operating system.
----
# Naive
For completeness here is a very explicit disk heavy naive solution.
string dir = @"C:\tmp";
while (true)
{
	Console.WriteLine($"");
	var desiredSinceUtc = DateTime.UtcNow.AddSeconds(-5);
	var files = System.IO.Directory.EnumerateFiles(dir, "*", System.IO.SearchOption.AllDirectories);
	var freshFiles = files.Where(f => System.IO.File.GetLastWriteTimeUtc(f) > desiredSinceUtc);
	foreach ( var f in freshFiles )
	{
		Console.WriteLine($"\t{f}");
	}
	await Task.Delay(TimeSpan.FromSeconds(5));
}
