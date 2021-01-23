    string[] files = Directory.GetFiles(path, pattern);
    foreach (string filename in files)
    {
        if (filename.EndsWith("AssemblyInfo.cs"))
        {
            continue;
        }
    }
