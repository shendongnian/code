    NameSpace ns = app.GetNamespace("MAPI");
    Folder folder = ns.GetDefaultFolder(Outlook_Folder_ID)
    foreach(Microsoft.Office.Interop.Outlook.Store store in stores)
    {
    	if(store.DisplayName == EmailID)
    	{
    		MAPIFolder inbox_folder = 
    		store.GetDefaultFolder(olDefaultFolders.OlFolderInbox);
    		If Sub_Folder <> "" Then
    			//Since we supplied Sub_Folder, set it to the value. In this case, RPA.
    			For each name as string in Sub_Folder.Split("\")
    			folder = folder.Folders(name)
    			Next
    		End If
    	}
    }
