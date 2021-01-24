    public static async Task<bool> TryDeleteFile(string filePath)
    {
    	try
    	{
    		var fi = new FileInfo(filePath);
    		if (fi.IsReadOnly) fi.IsReadOnly = false;
    		await Task.Run(() => fi.Delete());
    
            // or
            // await Task.Run(() => File.Delete(filePath));
    
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
