    private int GetFolderID(SPFolderCollection folders, string folder)
        {
            for (int i = 0; i < folders.Count - 1; i++)
            {
                if (folders[i].Item.DisplayName == folder)
                {
                    return i;
                }
            }
            return 999;
        }
