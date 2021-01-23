    public static List<string> getFiles(string path, List<string> files)
    {
        IEnumerable<string> fileInfo = null;
        IEnumerable<string> folderInfo = null;
        try
        {
            fileInfo = Microsoft.Experimental.IO.LongPathDirectory.
                EnumerateFiles(path);
        }
        catch
        {
        }
        if (fileInfo != null)
        {
            files.AddRange(fileInfo);
            //recurse through the subfolders
            folderInfo = Microsoft.Experimental.IO.LongPathDirectory.
                EnumerateDirectories(openFrom);
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
