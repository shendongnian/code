    // backup the CE database
    string databasePath = ""; // location of your database
    string backupPath = ""; // choose a backup path
    try
    {
        File.Copy(databasePath, backupPath);
    }
    catch 
    {
        Trace.TraceError("Error creating backup");
    }
 
    Process proc = Process.Start("wceload.exe", "\"" + Path.Combine(applicationPath, updateFileName) + "\"");
    proc.WaitForExit();
