	public void ProcessCsvFile(){
		using (FileSystemWatcher watcher = new FileSystemWatcher())
		{
			watcher.Path = args[1];         
		 
			// Only watch text files.
			watcher.Filter = "*.txt";
			// Add event handlers.     
			watcher.Created += (source,e)=>ProcessImportFile(e.FullPath);
	 
			// Begin watching.
			watcher.EnableRaisingEvents = true;
		   
			Console.WriteLine("Waiting for the file");
			Console.Read();
		}    
	}
