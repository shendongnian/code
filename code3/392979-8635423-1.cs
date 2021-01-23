    if (File.Exists(databasePath))
    {
        try 
        {
             File.Delete(databasePath);
        }
        catch 
        {
             Trace.TraceError("Error deleting new database");
        }
    }
    string databasePath = ""; // location of your database
    string backupPath = ""; // choose a backup path
    try
    {
        File.Copy(backupPath , databasePath);
    }
    catch 
    {
        Trace.TraceError("Error restoring backup");
    }
