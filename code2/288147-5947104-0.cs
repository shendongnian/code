    public void fnProcessDirectory(string strPath)
    {
        if (File.Exists(strPath))
        {
            fnProcessFile(strPath);
        }
        else if (Directory.Exists(strPath))
        {
            string[] fileEntries = Directory.GetFiles(strPath);
            string[] subdirEntries = Directory.GetDirectories(strPath);
            foreach (string fileName in fileEntries)
            {
                fnProcessFile(fileName);
            }
            foreach (string dirName in subdirEntries)
            {
                fnProcessDirectory(dirName);
            }
        }
    }
    public void fnProcessFile(string strPath)
    {
        //write the file name in the txt file
    }
