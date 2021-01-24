    protected virtual bool IsFileCorrupted(FileInfo file)
    {
        FileStream stream = null;
    
        try
        {
            stream = File.Open(FileMode.Open, FileAccess.Read, FileShare.None);
        }
        catch (IOException)
        {
           // File is corrupted
            return true;
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
    
        //file is not corrupted
        return false;
    }
