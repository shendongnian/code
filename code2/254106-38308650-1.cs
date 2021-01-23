    public static bool EraseDirectory(string folderPath, bool recursive)
    {
        //Safety check for directory existence.
        if (!Directory.Exists(folderPath))
            return false;
        foreach(string file in Directory.GetFiles(folderPath))
        {
            File.Delete(file);
        }
        //Iterate to sub directory only if required.
        if (recursive)
        {
            foreach (string dir in Directory.GetDirectories(folderPath))
            {
                EraseDirectory(dir, recursive);
            }
        }
        //Delete the parent directory before leaving
        Directory.Delete(folderPath);
        return true;
    }
