    var p = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "myAppName");
    if (!Directory.Exists(p)) Directory.CreateDirectory(p);
    using (var sw = new StreamWriter(Path.Combine(p, "log.txt"), true)
    {
        sw.WriteLine(str);
    }
