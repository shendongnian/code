    string sourceDir = @"C:\Backups";   // change this to the location of the files
    string[] bakList = Directory.GetFiles(sourceDir, "*.bak");
    try
    {
        foreach (string f in bakList)
        {
            File.Delete(f);
        }
    }
    catch (IOException ioex)
    {
        // failed to delete because the file is in use
    }
    catch (UnauthorizedAccessException uaex)
    {
        // failed to delete because file is read-only,
        // or user doesn't have permission
    }
