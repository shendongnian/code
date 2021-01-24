    public string FolderPath
    {
        get
        {
            return folderPath;
        }
        set
        {
            folderPath = value;
            Changed(nameof(FolderPath));
        }
    }
    ...
    folderViewModel.FolderPath = parent.FolderPath+"/"+folder.Name;
    await folderViewModel.GetFolderPathAsync();
    folderViewModel.FolderPath = "Loading...";
