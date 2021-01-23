    string basename = "log";
    string extention = ".txt";
    for (int i = 0; i < 300; i++)
    {
        using(var writer = new StreamWriter(Path.Combine(
            workingDir, string.Format("{0}{1:000}{2}" basename, i, extension), true))
        {
            // write file content using writer
        }
    }
