    private void RecursiveCreation(DirectoryInfo dir, string destination, string subPath = "")
    {
        foreach (var subdir in dir.GetDirectories())
        {
            string dirPath = Path.Combine(subPath, subdir.Name);
            Directory.CreateDirectory(Path.Combine(destination, dirPath));
            RecursiveCreation(subdir, destination, dirPath);
        }
        foreach (var file in dir.GetFiles())
        {
            File.Create(Path.Combine(destination, subPath, file.Name));
        }
    }
