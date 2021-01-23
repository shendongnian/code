    public IEnumerable<Folder> WalkFolderTree(FolderCollection folders)
    {
        foreach (var item in folders)
        {
            if (item.HasChildren)
            {
                WalkFolderTree(item.SubFolder);
            }
                yield return item;
        }
     }
