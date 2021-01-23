    const int BytesPerMb = 1024 * 1024;
    DirectoryInfo directory = new DirectoryInfo(@"x:\logs");
    FileInfo[] files = directory.GetFiles("*.xml");
    var grouper = new MaxAmountGrouper(5 * BytesPerMb);
    var groups = files.GroupBy(f => grouper.GetGroupId((int)f.Length));
    foreach (var g in groups)
    {
        long totalSize = g.Sum(f => f.Length);
        Console.WriteLine("Group {0}: {1} MB", g.Key, totalSize / BytesPerMb);
        foreach (FileInfo f in g)
        {
            Console.WriteLine("File: {0} ({1} MB)", f.Name, f.Length / BytesPerMb);
        }
        Console.WriteLine();
    }
