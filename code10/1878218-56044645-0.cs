    var tasks = new List<Task>();
    foreach (var d in DriveInfo.GetDrives())
    {
        tasks.Add( Search(d.RootDirectory.GetDirectories()));
    }
    Task.WaitAll(tasks.ToArray());
