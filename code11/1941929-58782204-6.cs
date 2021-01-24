    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    ...
    private string DataFolder
    {
    #if UNITY_EDITOR
        return Application.streamingAssetsPath;
    #else
        return Application.persitentDataPath;
    #endif
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
    #if UNITY_EDITOR
        AssetDataBase.Refresh();
    #endif
    }
