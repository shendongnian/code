	// Cache of upload managers keyed by their associated file extension
	private Dictionary<string, UploadManager> mManagers;
        // ... Add managers to cache in constructor ...
	public void Upload(string filename)
	{
		string extension = System.IO.Path.GetExtension(filename);
		// See if we have a manager for this extension
		UploadManager manager;
		if(mManagers.TryGetValue(extension, out manager))
		{
			// Validate the file
			// Note: This will call an abstract method in the UploadManager base
			//	 class that will be defined in the child classes.
			manager.Validate(filename);
		}
	}
