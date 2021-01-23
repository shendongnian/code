    private void ClearReadOnly(DirectoryInfo parentDirectory)
    {
    	if(parentDirectory != null)
    	{
    		parentDirectory.Attributes = FileAttributes.Normal;
    		foreach (FileInfo fi in parentDirectory.GetFiles())
    		{
    			fi.Attributes = FileAttributes.Normal;
    		}
    		foreach (DirectoryInfo di in parentDirectory.GetDirectories())
    		{
    			ClearReadOnly(di);
    		}
    	}
    }
