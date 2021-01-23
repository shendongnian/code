    public static bool IsValidFilename(string filename)
    {
        try
        {
            File.OpenRead(filename).Close();
        }
        catch (ArgumentException) { return false; }
        catch (Exception) { }
        return true;
    }
