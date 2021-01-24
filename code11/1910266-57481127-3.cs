    NameSpace ns = app.GetNamespace("MAPI");
    Folder folder = ns.GetDefaultFolder(Outlook_Folder_ID)
    foreach(Microsoft.Office.Interop.Outlook.Store store in stores)
    {
    	if(store.DisplayName == EmailID)
    	{
    		MAPIFolder inbox_folder = 
    		store.GetDefaultFolder(olDefaultFolders.OlFolderInbox);
    		if(Sub_Folder != "")
			{
				//Since we supplied Sub_Folder, set it to the value. In this case, RPA.
				foreach(string name in Sub_Folder.Split("\"))
				{
					folder = folder.Folders(name);
				}
			}
    	}
    }
