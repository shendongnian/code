    public int CountSubfolders(MAPIFolder folder)
    {
        int count = folder.Folders.Count;
    
        foreach (MAPIFolder subfolder in folder.Folders)
        {
            count += CountSubfolders(subfolder);
        }
    
        return count;
    }
