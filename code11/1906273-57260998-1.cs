       foreach(Store store in stores)
       {
          Outlook.MAPIFolder inbox_folder = 
          store.GetDefaultFolder(outlook.olDefaultFolders.olFolderInbox);
          ProcessFolder(inbox_folder);
       }
      ...    
    
      private void ProcessFolder(MAPIFolder folder)
      {
         //subfolders
         foreach(MAPIFolder subFolder in folder.Folders)
         {
            ProcessFolder(subFolder);
         } 
         //items
         foreach (Object item in folder.Items)
         {
         }
      }
