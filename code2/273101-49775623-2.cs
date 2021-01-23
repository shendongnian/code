    public static bool IsFullPath(string path)
    {
        try
        {
            return Path.GetFullPath(path) == path;
        }
        catch
        {
            return false;
        }
    }
    
