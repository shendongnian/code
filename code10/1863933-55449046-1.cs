    using (FileSystemWatcher watcher = new FileSystemWatcher(@"\\your unc path"))
    {
    	// Watch for changes in LastAccess and LastWrite times, and
    	// the renaming of files or directories.
    	watcher.NotifyFilter = NotifyFilters.LastAccess
    						 | NotifyFilters.LastWrite
    						 | NotifyFilters.FileName
    						 | NotifyFilters.DirectoryName;
    
    	// Only watch text files.
    	watcher.Filter = "*.txt";
    
    	watcher.Created += (s, e) => { Console.WriteLine($"Created {e.Name}"); };
    	watcher.Deleted += (s, e) => { Console.WriteLine($"Deleted {e.Name}"); };
    	watcher.Error += (s, e) => { Console.WriteLine($"Error {e.GetException()}"); };
    
    
    	// Begin watching.
    	watcher.EnableRaisingEvents = true;
    
    	// Wait for the user to quit the program.
    	Console.WriteLine("Press 'q' to quit the sample.");
    	while (Console.Read() != 'q') ;
    }
 
