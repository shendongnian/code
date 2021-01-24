    public void createFile(string name)
    {
        string directory = Directory.GetCurrentDirectory();
        string path = Path.Combine(directory, name);
        if (File.Exists(path)) {
            File.WriteAllText(path, "FILE EXISTS");
        } else {
            File.WriteAllText(path, "FILE DID NOT EXIST AND HAS BEEN CREATED");
        }
    }
