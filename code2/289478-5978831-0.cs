    static bool IsArchive(string filename)
    {
        bool result = false;
        try
        {
            new ArchiveFile(File.OpenRead(filename));
            result = true;
        }
        catch
        {
            //log if you're going to do something about it
        }
        return result;
    }
