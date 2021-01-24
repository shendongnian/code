    string directoryName = "\\apollon\User\Walzenbach"
    DirectoryInfo directory = new DirectoryInfo(directoryName);
    // TODO: exception if !directory.Exists;
    var result = directory.EnumerateDirectories()
        .Select(subDirectory => new
        {
            SubDirectory = subDirectory,       // This is a DirectoryInfo
            // if you prefer the name, instead of the Directory:
            SubDirectoryName = subDirectory.Name,
            // count the number of subfolders of this subfolder:
            SubFolderCount = subFolder.EnumerateDirectories().Count(),
        });
