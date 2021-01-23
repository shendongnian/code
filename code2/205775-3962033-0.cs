    static void Main(string[] args)
    {
        var files = new List<string>();
        foreach (var file in Directory.GetFiles("<path to your log files>"))
        {
            files.Add(file);
        }
        files.Sort(
            new Comparison<string>(
                (a, b) => new FileInfo(b).CreationTime.CompareTo(new FileInfo(a).CreationTime)
            )
        );
        foreach (var file in files.Skip(20))
        {
            // Delete file.
        }
    }
