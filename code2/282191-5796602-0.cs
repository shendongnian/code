    static bool IsWriteProtected(string file)
    {
        try
        {
            using (File.OpenWrite(file)) ;
        }
        catch (UnauthorizedAccessException ex)
        {
            return true;
        }
        return false;
    }
