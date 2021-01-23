    DirectoryEntry directoryEntry = new DirectoryEntry(path);
    directoryEntry.Username = "username";
    directoryEntry.Password = "password";
    bool exists = false;
    // Validate with Guid
    try
    {
        directoryEntry.Guid;
        exists = true;
    }
    catch (COMException)
    {
       exists = false; 
    }
