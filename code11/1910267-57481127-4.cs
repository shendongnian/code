    public bool ProcessFolder(MAPIFolder folder)
    {
    	bool found = false;
    	foreach(MAPIFolder subFolder in folder.Folders)
    	{
    		if(subFolder.FullFolderPath == folderPath)
    		{
    			found = true;
    			return found;
    		}
    		else
    		{
    			found = ProcessFolder(subFolder);
        		if(found)
    			{
					return found;
				}
    		}
    	}
    	return found;
    }
    
    
    
    NameSpace ns = app.GetNamespace("MAPI");
    Folder folder = ns.GetDefaultFolder(Outlook_Folder_ID)
    foreach(Microsoft.Office.Interop.Outlook.Store store in stores)
    {
    	if(store.DisplayName == EmailID)
    	{
    		MAPIFolder inbox_folder = 
    		store.GetDefaultFolder(olDefaultFolders.OlFolderInbox);
    		if(ProcessFolder(inbox_folder))
    		{
    			foreach(string name in folderPath.Split("\"))
    			{
    				folder = folder.Folders(name);
    			}
    			//Proceed to do code here
    		}
    		else
    		{
    			//Throw an error, do something else.
    		}
    	}
    }
