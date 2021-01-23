    FileIOPermission f = new FileIOPermission(FileIOPermissionAccess.Read, "C:\\yourDir");
    f2.AddPathList(FileIOPermissionAccess.Read, "C:\\example\\out.txt");
    try
    {
        f2.Demand();
    }
    catch (SecurityException s)
    {
        Console.WriteLine(s.Message);
    }
