    var path = Path.Combine(Application.persistentDataPath, "FileName.txt")
    using (var fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        using (var sr = new StreamReader(fs))
        {
            var json = sr.ReadToEnd();
            ...
        }
    }
