    private BlockingCollection<string> rowsQueue;
    private void ProcessFiles() {
	   this.rowsQueue = new BlockingCollection<string>(new ConcurrentBag<string>(), 1000);
	   ReadFiles(new List<string>() { "file1.txt", "file2.txt" });
	   while (!this.rowsQueue.IsCompleted || this.rowsQueue.Count > 0)
	   {
		   string line = this.rowsQueue.Take();
		
		   // Do something
	   }
    }
    private Task ReadFiles(List<string> fileNames)
    {
	    Task task = new Task(() =>
	    {
		    Parallel.ForEach(
		    fileNames,
		    new ParallelOptions
		    {
			    MaxDegreeOfParallelism = 10
		    },
			    (fileName) =>
			    {
				    using (StreamReader sr = File.OpenText(fileName))
				    {
					    string line = String.Empty;
					    while ((line = sr.ReadLine()) != null)
					    {
						       this.rowsQueue.Add(line);
					    }
				    }
			    });
    
		    this.rowsQueue.CompleteAdding();
	    });
    
	    task.Start();
    
	    return task;
    }
