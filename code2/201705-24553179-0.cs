    void SetReadOnlyFlagForAllFiles(DirectoryInfo directory, bool isReadOnly)
    {
        // Iterate over ALL files using "*" wildcard and choosing to search all directories.
        foreach(FileInfo File in directory.GetFiles("*", SearchOption.All.Directories))
        {
            if(isReadOnly)
            {
                // Unset read only flag.
                File.Attributes |= FileAttributes.ReadOnly;
            }
            else
            {
                // Set read only flag.
                File.Attributes &= ~FileAttributes.ReadOnly;
            }
        }
    }
