    DirectoryEntry directoryEntry = new DirectoryEntry(path);
    directoryEntry.Username = "username";
    directoryEntry.Password = "password";
    bool exists = false;
    // Validate with GUID
    try
    {
        directoryEntry.GUID;
        exists = true;
    }
    catch (COMException)
    {
       exists = false; 
    }
