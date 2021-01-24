    using System.Linq;
    using System.FileIO
    private string FindVideoFile(string folderPath, string partialFileName)
    {
        if(!Directory.Exists(folderPath)
        {
            Debug.LogError($"The folder {folderPath} does not exist!", this);
            return null;
        }
    
        var result = Directory.GetFiles(folderPath, partialFileName, SearchOption.TopDirectoryOnly).FirstOrDefault();
    
        return result;
    }
