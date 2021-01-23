    private int GetFolderID(SPFolderCollection folders, string folder)
        {
            for (int i = 0; i < folders.Count; i++)
            {
                if (folders[i].Name == folder)
                {
                    return i;
                }
            }
            return 999;
        }
