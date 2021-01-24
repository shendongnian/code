	void CleanupFiles(String sPath, int iDayDelAge)
    {
		if (iDayDelAge == 0) // enabled?
		{
            return;
        }  
			
        // Check for aged files to remove
		foreach (String file in Directory.GetFiles(sPath))
		{
			FileInfo fi = new FileInfo(file);
			if (fi.LastWriteTime < DateTime.Now.AddDays(iDayDelAge * -1))  // overdue?
			{
				fi.Delete();
			}
		}
		foreach (String subfolder in Directory.GetDirectories(sPath))
		{
			var dirInfo = new DirectoryInfo(subfolder);
			dirInfo.Delete(true); 
		}
    }
