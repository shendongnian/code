    private string DataFolder
    {
        return Application.isEditor ? Application.streamingAssetsPath : Application.persitentDataPath;
    }
    private string GetFilePath(string fileName)
    {
        return Path.Combine(DataFolder, fileName);
    }
    //                  | Little typo here btw
    //                  v
    private void WriteTopFile(string fileName, string json)
    {
        string filePath = GetFilePath(fileName);
        // Create folder if not exists
        if(!Directory.Exists(DataFolder)
        {
            Directory.CreateDirectory(DataFolder);
        }
        using(var fileStream = new FileStream(filePath, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        } 
    }
