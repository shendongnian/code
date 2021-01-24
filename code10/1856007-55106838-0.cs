    var p = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "myAppName", "log.txt");
    using (var sw = new System.IO.StreamWriter(p, true))
    {
        sw.WriteLine(str);
    }
