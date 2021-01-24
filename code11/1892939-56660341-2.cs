    public void DeleteFunction(string FolderName)
    {
        string[] files = Directory.GetFiles(GetTempSavePath(clientId), "*", SearchOption.AllDirectories);
        List<string> filenames = files.Select(file => Path.GetFileName(file)).ToList();
    }
