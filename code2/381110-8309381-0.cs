    public static ZipEntry GetEntryExt(this ZipFile file, string fileName)
    {
        foreach (ZipEntry entry in file)
        {
            if (entry.IsFile && entry.Name.EndsWith(fileName))
                return entry;
        }
    
        return null;
    }
