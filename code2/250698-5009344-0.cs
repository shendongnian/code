    string[] subdirs;
    try
    {
        subdirs = Directory.GetDirectories(path);
    }
    catch (IOException e)
    {
        // Do whatever you need here
        subdirs = new string[0];
    }
