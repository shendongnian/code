    string [] dirs = System.IO.Directory.GetDirectories("C:\\Test\\");
    string[] files = System.IO.Directory.GetFiles("C:\\Test\\");
    if (dirs.Length == 0 && files.Length == 0)
    {
        // Is Empty
    }
    else
    {
        // Not Empty
    }
