    public void SaveAvatarToFileSystem()
    {
        CreateAvatarDirectory();
        _file.SaveAs(FormattedFileName);
    }
    protected internal virtual void CreateAvatarDirectory()
    {
        Directory.CreateDirectory(AvatarDirectory);
    }
