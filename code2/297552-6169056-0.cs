    byte[] bytes = ...
    string name = Path.ChangeExtension(Path.GetRandomFileName(), ".wav");
    string path = Path.Combine(Path.GetTempPath(), name);
    File.WriteAllBytes(path, bytes);
    Process.Start(path);
