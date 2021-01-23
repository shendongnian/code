    public int countRootFolders(Microsoft.Office.Interop.Outlook.MAPIFolder aFolder)
    {
        int rootCount = aFolder.Folders.Count;
    
        foreach (Microsoft.Office.Interop.Outlook.MAPIFolder subfolder in aFolder.Folders)
        {
            rootCount += countRootFolders( subFolder );
        }
    
        return rootCount;
    }
