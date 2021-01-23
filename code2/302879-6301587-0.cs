    string pathPrefix;
    if(System.Diagnostics.Debugger.IsAttached())
    {
        pathPrefix = System.IO.Path.GetFullPath(Application.StartupPath + "\..\..\resources\");
    }
    else
    {
        pathPrefix = Application.StartupPath + "\resources\";
    }
    Process.Start(pathPrefix + "Textfile.txt");
