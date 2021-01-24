    public async Task<bool> DeleteFiles(IList<string> filesToBeDeleted)
    {
        ...
        foreach (string filePath in filesToBeDeleted)
        {
            success = success && await Task.Run(() => IOHelper.TryDeleteFile(filePath));
            ...
        }
        return success;
    }
