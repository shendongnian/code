    void Main()
    {
    	var directoryInfo = new DirectoryInfo(@"C:\");
    	var currentUser = WindowsIdentity.GetCurrent();
    	var files = directoryInfo.GetFiles(".").Where(f => CanRead(currentUser, f.FullName));
    }
    
    private bool CanRead(WindowsIdentity user, string filePath)
    {
    	if(!File.Exists(filePath))
    		return false;
      
      	try
    	{
    		var fileSecurity = File.GetAccessControl(filePath, AccessControlSections.Access); 
    		foreach(FileSystemAccessRule fsRule in fileSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier)))
    		{
    			foreach(var usrGroup in user.Groups)
    			{
    				if(fsRule.IdentityReference.Value == usrGroup.Value)
    					return true;
    			}
    		}
    	} catch (InvalidOperationException) {
    		//File is in use
    		return false;
    	}
    
    	return false;
    }
