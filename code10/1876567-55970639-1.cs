    public static bool TryDeleteFile(string filePath)
    {
    	try
    	{
    		var fi = new FileInfo(filePath);
    		if (fi.IsReadOnly) fi.IsReadOnly = false;
    
    		using (new FileStream(filePath, FileMode.Truncate, FileAccess.ReadWrite, FileShare.Delete, 1,
    			FileOptions.DeleteOnClose | FileOptions.Asynchronous))
    		{
    		}
    
    		return true;
    	}
    	catch (FileNotFoundException)
    	{
    		return true;
    	}
    	catch (Exception ex)
    	{
                    // Log Exception
    		return false;
    	}
    }
