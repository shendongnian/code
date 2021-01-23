    foreach (string item in Directory.GetFileSystemEntries(@"c:\d1\d2\d3")) {
        string absoluteSource = Path.Combine(@"c:\d1\d2\d3", item);
        string absoluteTarget = Path.Combine(@"c:\d1\new", item);
        if (File.GetAttributes(absoluteSource) & FileAttributes.Directory != 0) {
            Directory.Move(absoluteSource, absoluteTarget);
        } else {
            File.Move(absoluteSource, absoluteTarget);
        }
    }
