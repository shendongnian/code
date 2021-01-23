    public static bool IsValidFilename(string filename)
    {
        try
        {
            File.OpenRead(filename).Close();
            //return false; // if file mustn't exist
        }
        catch (ArgumentException) { return false; }
        catch (Exception) { }
        return true;
    }
