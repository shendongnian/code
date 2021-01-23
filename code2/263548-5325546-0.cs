    public static bool isFileLocked(string filename)
    {
    	if (!File.Exists(filename)) throw new FileNotFoundException("File not found!", filename);
    	
    	FileStream fs = null;
    	try
    	{
    		fs = File.Open(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
    		return false;
    	}
    	catch (IOException)
    	{
    		return true;
    	}
    	catch (Exception)
    	{
    		throw;
    	}
    	finally
    	{
    		if (fs != null)
    		{
    			fs.Close();
    			fs = null;
    		}
    	}
    }
