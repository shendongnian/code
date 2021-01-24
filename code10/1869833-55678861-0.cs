    private void _bgwCopyOperation_DoWork(object sender, DoWorkEventArgs e)
    {
    	if (no == 0)
    	{
    		no = 1;
    		Dirr = sourceDirName;
    		Dirr2 = destDirName;
    		Count = Directory.GetFiles(Dirr, "*.*", SearchOption.AllDirectories).Length;
    		Count = 100 / Count;
    	}    
    	// Get the subdirectories for the specified directory.
    	DirectoryInfo dir = new DirectoryInfo(sourceDirName);
    
    	if (!dir.Exists)
    	{
    		throw new DirectoryNotFoundException(
    			"Source directory does not exist or could not be found: "
    		+ sourceDirName);
    	}    
	    DirectoryInfo[] dirs = dir.GetDirectories();
    	// If the destination directory doesn't exist, create it.
    	if (!Directory.Exists(destDirName))
    	{
    		Directory.CreateDirectory(destDirName);
    	}
	    // Get the files in the directory and copy them to the new location.
    	FileInfo[] files = dir.GetFiles();
    	foreach (FileInfo file in files)
    	{
    		string temppath = Path.Combine(destDirName, file.Name);
    		file.CopyTo(temppath, false);
    		Count2 = Count2 + 1;
    		
            //Update progressbar here
    		_bgwCopyOperation.ReportProgress(Count2 * Count);
    	}
	    // If copying subdirectories, copy them and their contents to new location.
    	if (copySubDirs)
    	{
    		foreach (DirectoryInfo subdir in dirs)
    		{
    			string temppath = Path.Combine(destDirName, subdir.Name);
    			DirectoryCopy(subdir.FullName, temppath, copySubDirs);
    		}
    	}
    }
    private void _bgwCopyOperation_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    	progressBar1.Value = e.ProgressPercentage;
    }
