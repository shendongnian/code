    public static List<string> getFiles(string path, List<string> files)
    {
        IEnumerable<string> fileInfo = null;
        IEnumerable<string> folderInfo = null;
        try
        {
            fileInfo = Directory.EnumerateFiles(str);
        }
        catch
        {
        }
        if (fileInfo != null)
        {
            files.AddRange(fileInfo);
            //recurse through the subfolders
            fileInfo = Directory.EnumerateDirectories(str);
            foreach (string s in folderInfo)
            {
                try
                {
                    getFiles(s, files);
                }
                catch
                {
                     
                }
            }
        }
        return files;
    }
