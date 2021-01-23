    void SetReadOnlyFlagForAllFiles(DirectoryInfo directory, bool isReadOnly)
    {
        // Iterate over ALL files using "*" wildcard and choosing to search all directories.
        foreach(FileInfo File in directory.GetFiles("*", SearchOption.All.Directories))
        {
            // Set flag.
            File.IsReadOnly = isReadOnly;
        }
    }
