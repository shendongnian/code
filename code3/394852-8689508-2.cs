	public void CopyFiles(string[] filenames, string dest) {
		// Begin a "Task", telling it how many "Steps" to expect:
		Progress.BeginTask(filenames.Length); 
		for (int i = 0; i < filenames.Length; i++) {
			// Report progress
			Progress.NextStep(); 
			
			CopyFile(filenames[i], dest);
		}
		// The task is finished:
		Progress.EndTask();
	}
	
	public void CopyFile(string filename, string dest) {
		var fileInfo = new FileInfo(filename);
		int blockSize = 256;
		// This will be a sub-task that will contribute to overall progress
		Progress.BeginTask(fileInfo.FileSize / blockSize);
		
		for (int i = 0; i < fileInfo; i += blockSize) {
			Progress.NextStep();
			
			// ... Copy the file or whatever ...
		}
		
		Progress.EndTask();
	}
