    foreach(string s in filePaths)
    {
    if (s.Contains(".jpg"))
    {
        CallYourFunction(System.IO.Path.GetFileName(s));
    }
    }
