    private static void FileCleanup(string directoryName)
    {
        try
        {
            string[] filenames = Directory.GetFiles(directoryName);
            foreach (string filename in filenames)
            {
                File.Delete(filename);
            }
            if (Directory.Exists(directoryName))
            {
                Directory.Delete(directoryName);
            }
        }
        catch (Exception ex)
        {
           // you might want to log it, or swallow any exceptions here
        }
    }
