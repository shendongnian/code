    string root = Path.GetDirectoryName(Application.ExecutablePath);
    List<string> FullFileList = Directory.GetFiles(root, "*.*", SearchOption.AllDirectories)
        .Where(name =>
        { 
            return !(name.EndsWith("dmp") || name.EndsWith("jpg"));
        })
        .Select(file => file.Replace(root, "")
        .ToList();
