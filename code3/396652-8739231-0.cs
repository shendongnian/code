    private static string getLongestFilename(string path)
    {
        int maxLength = 0;
        string longestFile = string.Empty;
        DirectoryInfo di = new DirectoryInfo(path);
        foreach (FileInfo fi in di.GetFiles())
        {
            if (fi.FullName.Length > maxLength)
            {
                longestFile = fi.FullName;
                maxLength = fi.FullName.Length;
            }
        }
        return longestFile;
    }
