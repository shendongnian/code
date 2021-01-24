    public List<string> GetFileList(string adlsPath, string prefix)
    {
        var prefixes = prefix?.Split(',');
        return prefixes != null && adlsClient.CheckExists(adlsPath)
            ? adlsClient.EnumerateDirectory(adlsPath)
                .Where(f => f.Type == DirectoryEntryType.FILE &&
                            prefixes.Any(p => f.Name.StartsWith(p)))
                .Select(f => f.Name)
            : new List<string>();
    }
